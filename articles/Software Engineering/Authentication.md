- A JWT is a set of claims (JSON property–value pairs) that together make up a JSON object. 
  
  It consists of three parts:
  
  1. Header: Consists of two properties: { "alg": "HS256", "typ": "JWT" }. alg is the algorithm that is used to encrypt the JWT.
  2. Payload: This is where the data to be sent is stored; this data is stored as JSON property–value pairs.
  3. Signature: This is created by encrypting, with the algorithm specified in the header: 
  (i) the base64Url-encoded header, 
  (ii) base64Url-encoded payload
  (iii) a secret (or a private key)
  
  Format: {header}.{payload}.{signature}
  
  https://openid.net/specs/draft-jones-json-web-token-07.html#ExampleJWT
# Encryption 

Symmetric key and asymmetric keys

A JWT can be encrypted using either a symmetric key (shared secret) or asymmetric keys (the private key of a private–public pair).

1. Symmetric key: Both encryption (JWT signing) and verification are done with the symmetric key—also known as the shared secret.
2. Asymmetric keys: The encryption (JWT signing) is done with the private key, and verification is done with the public key.
- # Tools
  
  https://jwt.io/
  https://token.dev/
  
  # Reference
- [A Beginner's Guide to JWTs](https://developer.okta.com/blog/2020/12/21/beginners-guide-to-jwt) for more information
- https://openid.net/
- https://aws.amazon.com/kms/
- https://altostra.com/blog/asymmetric-jwt-signing-using-aws-kms
- https://security.stackexchange.com/questions/188552/amazon-aws-kms-concept-of-signing-in-general-and-with-jwt
-