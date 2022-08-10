## Create Self-Signed SSL Certificate

1. Open a command prompt window
2. Run ```ubuntu```
3. Copy and Paste the following code. This will generate a .crt and a .key using [OpenSSL](https://www.openssl.org/)
``` 
PARENT="localhost"
openssl req \
-x509 \
-newkey rsa:4096 \
-sha256 \
-days 18250 \
-nodes \
-keyout $PARENT.key \
-out $PARENT.crt \
-subj "/CN=${PARENT}" \
-extensions v3_ca \
-extensions v3_req \
-config <( \
  echo '[req]'; \
  echo 'default_bits= 4096'; \
  echo 'distinguished_name=req'; \
  echo 'x509_extension = v3_ca'; \
  echo 'req_extensions = v3_req'; \
  echo '[v3_req]'; \
  echo 'basicConstraints = CA:FALSE'; \
  echo 'keyUsage = nonRepudiation, digitalSignature, keyEncipherment'; \
  echo 'subjectAltName = @alt_names'; \
  echo '[ alt_names ]'; \
  echo "DNS.1 = ${PARENT}"; \
  echo '[ v3_ca ]'; \
  echo 'subjectKeyIdentifier=hash'; \
  echo 'authorityKeyIdentifier=keyid:always,issuer'; \
  echo 'basicConstraints = critical, CA:TRUE, pathlen:0'; \
  echo 'keyUsage = critical, cRLSign, keyCertSign'; \
  echo 'extendedKeyUsage = serverAuth, clientAuth')

openssl x509 -noout -text -in $PARENT.crt
```
3. Run ```openssl pkcs12 -export -out $PARENT.pfx -inkey $PARENT.key -in $PARENT.crt``` to get a .pfx
4. Run ```explorer.exe .``` to open Windows Explorer and get the Certificate files

**Notes**

- CRT file does not contain the private key
- KEY file contains the private key
- PFX file contains the private key, but it's protected by a password (eg. 12345)

## Import Self-Signed SSL Certificate

Reference
- [Import-PfxCertificate](https://docs.microsoft.com/en-us/powershell/module/pki/import-pfxcertificate?view=windowsserver2022-ps)
- [Trusted Root Certification Authorities Certificate Store](https://docs.microsoft.com/en-us/windows-hardware/drivers/install/trusted-root-certification-authorities-certificate-store)

1. Open a PowerShell window with admin rights 
2. Run ```Get-Credential -UserName 'Enter password below' -Message 'Enter password below'```
3. Run ```Import-PfxCertificate -FilePath "C:\GitHub\Workbench\Misc\SSL\localhost.pfx" -CertStoreLocation Cert:\LocalMachine\Root\ -Password $mypwd.Password```

## Configure Certificate in ASP.NET

- See [Documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-6.0)
- See [Example](https://github.com/leandromonaco/Workbench/commit/5bf095de315630410f10bbb98d667a3148beabba)

## Configure Certificate in Angular

- See [Documentation](https://angular.io/cli/serve)
- See [Example](https://github.com/leandromonaco/Workbench/commit/ef5d07e754ffe3ff812438013fa4212a5b776545)

## Manage Certificate Private keys 

1. Go to Windows -> type "run" -> mmc
2. Once the mmc window is up -> Add Snap-in -> Add certificate -> Local Computer 
3. Go to Personal -> Certificate -> Select the certificate
4. Right Click Certificate -> All tasks -> Manage Private keys 

Notes:
- Private key must be exportable when installing the certificate
- In Windows 10 1809, it seems that the Manage Private Keys option is available only to certificates in the Personal store. The workaround is to drag and drop the certificate there, add permissions as needed and drag it back to where you need it.

# Reference Material

https://howhttps.works/
