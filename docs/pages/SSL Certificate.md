## Create Self-Signed Certificate
> **Note**
> This process requires WSL2 and Ubuntu. Read [here](Docker%20Desktop.md) for installation steps.


1. Open a command prompt window
2. Run `ubuntu`
3. Create `san.cnf`
  ```
  [req]
  distinguished_name = req_distinguished_name
  req_extensions = v3_req
  [req_distinguished_name]
  [v3_req]
  basicConstraints = CA:FALSE
  keyUsage = nonRepudiation, digitalSignature, keyEncipherment
  subjectAltName = @alt_names
  [alt_names]
  DNS.1   = local.mydomain.dev
  DNS.2   = support.mydomain.dev
  DNS.3   = test.mydomain.dev
  DNS.4   = automation.mydomain.dev
  ```
 4. Create a private key for the CA
 `openssl genpkey -algorithm RSA -out ca.key`
 5. Create a self-signed certificate for the CA
 `openssl req -x509 -new -key ca.key -out ca.crt -days 36500` (this will prompt you for information about the CA, such as its name and location.)
 6. Create a private key for the server
 `openssl genpkey -algorithm RSA -out server.key`
 7. Create a certificate signing request (CSR) for the server
 `openssl req -new -key server.key -out server.csr -subj "/CN=mydomain.dev" -config san.cnf` (this will prompt you for information about the server, such as its name and location.)
 8. Sign the server's CSR with the CA
 `openssl x509 -req -days 36500 -in server.csr -CA ca.crt -CAkey ca.key -CAcreateserial -out server.crt -extensions v3_req -extfile san.cnf`
 9. Verify the Certificate
 `openssl verify -CAfile ca.crt -verify_hostname local.mydomain.dev server.crt`
 10. Generate PFX files
 ``` 
  openssl pkcs12 -export -out ca.pfx -inkey ca.key -in ca.crt -passout pass:P4ssW0rd
  openssl pkcs12 -export -out server.pfx -inkey server.key -in server.crt -passout pass:P4ssW0rd
 ```
 11. Run `explorer.exe .` to open Windows Explorer and get the PFX Certificate files
 12. Copy files to `C:\Dev\SSL\`
 13. Open a PowerShell window with admin rights
 14. Execute `Import-PfxCertificate -FilePath .\ca.pfx -Password (ConvertTo-SecureString -String 'P4ssW0rd' -AsPlainText -Force) -CertStoreLocation Cert:\LocalMachine\Root`
 15. Execute `Import-PfxCertificate -FilePath .\server.pfx -Password (ConvertTo-SecureString -String 'P4ssW0rd' -AsPlainText -Force) -CertStoreLocation Cert:\LocalMachine\My`
 16. Import PFX Certificate
  ```
    $mypwd = ConvertTo-SecureString "password from step 4" -AsPlainText -Force
    Import-PfxCertificate -FilePath "C:\Dev\SSL\*.mydomain.dev.pfx" -CertStoreLocation Cert:\LocalMachine\My\ -Password $mypwd.Password
  ```
  
Trust the CA on Firefox: `Settings -> Privacy & Security -> View Certificates -> Authorities -> import ca.crt`
  
  **Notes**
- CRT file does not contain the private key
- KEY file contains the private key
- PFX file contains the private key, but it's protected by a password (eg. P4ssW0rd)

## Configure Certificate in [[ASP.NET]]
- See [Documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel/endpoints?view=aspnetcore-6.0)
- See [Example](https://github.com/leandromonaco/Workbench/commit/5bf095de315630410f10bbb98d667a3148beabba)
## Configure Certificate in [[Angular]]
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
## Documentation
  [How HTTPS Works](https://howhttps.works/)
- [Import-PfxCertificate](https://docs.microsoft.com/en-us/powershell/module/pki/import-pfxcertificate?view=windowsserver2022-ps)
- [Trusted Root Certification Authorities Certificate Store](https://docs.microsoft.com/en-us/windows-hardware/drivers/install/trusted-root-certification-authorities-certificate-store)
- [Create a CSR](https://www.filecloud.com/supportdocs/fcdoc/latest/server/filecloud-administrator-guide/installing-filecloud-server/post-installation/ssl-configuration/use-ssl-on-linux/create-a-csr-for-filecloud)

## Using CloudFlare as CA

1. Go to https://dash.cloudflare.com
2. Create a Website
3. Run `Ubuntu`
4. Run `openssl req -new -newkey rsa:2048 -nodes -keyout server.key -out server.csr`
5. When prompted **Common Name**, make sure you use a wildcard address `*.mydomain.dev`
6. Run `ls` and check if `server.csr` is listed
7. Run `cat server.csr`
8. Copy the CSR content
9. Go to CloudFare -> Website -> SSL/TLS -> Origin Server -> Create Certificate
10. Select "Use my private key and CSR"
11. Copy content from step 8
12. Click Create
13. Select PEM Format
14. Copy content into a notepad and save as newsslcertificate.crt
15. Generate PFX `openssl pkcs12 -export -out server.pfx -inkey server.key -in server.crt -passout pass:P4ssW0rd`

