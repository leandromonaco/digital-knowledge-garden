  > [[articles/Tools/Powershell]] 7+ is required
  
  1. Run `Install-Module -Name IISAdministration -Scope AllUsers -AllowClobber`
  2. Run `New-IISSite -Name 'website_name' -PhysicalPath 'C:\Inetpub\wwwroot' -BindingInformation "*:443:hostname1.com" -Protocol https -SslFlag "Sni" -CertificateThumbPrint "[Insert Thumbprint]" -CertStoreLocation "Cert:\LocalMachine\My" -Force`
  3. Run `New-IISSiteBinding -Name "website_name" -BindingInformation "*:443:hostname2.com" -Protocol https -SslFlag "Sni" -CertificateThumbPrint "[Insert Thumbprint]" -CertStoreLocation "Cert:\LocalMachine\My" -Force`