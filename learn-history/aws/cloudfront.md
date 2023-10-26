# cloudfront

    CDN, Support deploy to specific regions or full region, support integrated with WAF, support custom DNS name and certification.
    Web Distribution: for media files, html, picture, js,css...
    RTMP Distribution: for adobe flash service RTMP protocol.

    Distributions deploy configuration to edge locations, it can takes up-to 45 minutes.
    Edge locations provide content to client, if no content, then either retrive from regional edge location or delegate regional edge location retrive from Origin source location.

    define origins and use behaviour settings to mapping origin.

    origin can be s3 or on-premise, if s3 the protocol between viewer , edge location and origion is force matched (both https or http).
    while custom origin can specify whether the protocol is match, port of origin, SSL protocol for origin between edge localtion.

## Origin Settings
### Restrict Bucket Access 
    use Origin Access Identity (OAI) to access the S3 bucket (can remove S3 public access, so it only can access through cloudfront)

## Behavior Settings
    Path Partten: *, /foldername ...
    Cache policy: default not include header/query string/ cookies, can customized to cache include them countered.

### Restrict Viewer Access:
    We can use an existing identity to sign URL/cookies for access object in S3 buckets.
    Signed URL: allow to access an object with the permission of signed identity.

    Cookies: allow access an object type or folder/area

## Restrictions
    only define geo-restriction settings to whitelist / blacklist on countries.

    anything else need use 3rd party restrictions.

## Feild level Encryption
    Use key pair to encrypt communication between client, edge location, origin.

## cloudfront cache optimize
    specify apporate TTL value.
    enable query string or cookies for cache by different cookies/querystring

## ACM
    certifaction manager, renew, free