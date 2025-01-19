
> **Note**
> This process requires WSL2 and Ubuntu. Read [here](Docker%20Desktop.md) for installation steps.


1. Open a command prompt window
2. Run `ubuntu`
3. Create `certificate.cnf`
  ```
[req]
default_bits= 2048
default_keyfile= keyfile.pem
distinguished_name= req_distinguished_name
attributes= req_attributes
prompt= no
output_password= mypass
req_extensions= v3_req

[v3_req]
basicConstraints= CA:FALSE
keyUsage= nonRepudiation, digitalSignature, keyEncipherment
subjectAltName = @alt_names

[alt_names]
DNS.1   = local.company.dev
DNS.2   = support.company.dev
DNS.3   = test.company.dev
DNS.4   = automation.company.dev

[req_distinguished_name ]
C= AU
ST= QLD
L= Brisbane
O= company Local
OU= Technology
CN= *.company.dev
emailAddress=leandro@company.com

[req_attributes]
challengePassword= C0mp4ny
  ```
4. `openssl req -new -newkey rsa:2048 -nodes -keyout ca.key -out ca.csr -config certificate.cnf`
5. `openssl req -new -newkey rsa:2048 -nodes -keyout server.key -out server.csr -config certificate.cnf`
6. `openssl req -x509 -new -key ca.key -out ca.crt -days 36500 -config certificate.cnf`
7. `openssl x509 -req -days 36500 -in server.csr -CA ca.crt -CAkey ca.key -CAcreateserial -out server.crt -extensions v3_req -extfile certificate.cnf`
8. `openssl verify -CAfile ca.crt -verify_hostname local.company.dev server.crt`

## PFX Export

Required to be visible on IIS, which needs a private key associated to the certificate.

1. `openssl pkcs12 -export -out ca.pfx -inkey ca.key -in ca.crt -passout pass:C0mp4ny`
2. `openssl pkcs12 -export -out server.pfx -inkey server.key -in server.crt -passout pass:C0mp4ny`

## Import into Windows Certificate Store

1. `Import-PfxCertificate -FilePath C:\Dev\SSL\ca.pfx -Password (ConvertTo-SecureString -String 'C0mp4ny' -AsPlainText -Force) -CertStoreLocation Cert:\LocalMachine\Root`
2. `Import-PfxCertificate -FilePath C:\Dev\SSL\server.pfx -Password (ConvertTo-SecureString -String 'C0mp4ny' -AsPlainText -Force) -CertStoreLocation Cert:\LocalMachine\My`

## Firefox
Trust the Certificate Authority on #Firefox: `Settings -> Privacy & Security -> View Certificates -> Authorities -> import ca.crt`

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

## Difference between CRT and PFX files
A .crt (or .cer or .cert) file usually contains a single X.509 encoded digital certificate, which is what is typically used for SSL/TLS encryption on websites. A .pfx (personal exchange format) file, on the other hand, is a password-protected data file that contains a private key, public key, and typically a chain of digital certificates. The main difference between the two is that a .pfx file contains both the private key and the public key, while a .crt file contains only the public key. Additionally, a .pfx file can include multiple certificates, while a .crt file typically only contains one.

**Notes**
- CRT file does not contain the private key
- KEY file contains the private key
- PFX file contains the private key, but it's protected by a password (eg. C0mp4ny)

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

