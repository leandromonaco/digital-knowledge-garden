**Test Project:** https://github.com/leandromonaco/workbench/tree/a6a4f3fce48edf2e50d75b49260d9d8a831c9863/MicroserviceTemplate/src/FeatureManagement.API
# Objective

To implement a Feature Management solution that allows us to change application behaviour without changing code.

# AWS AppConfig

[AWS AppConfig](https://docs.aws.amazon.com/appconfig/latest/userguide/what-is-appconfig.html "https://docs.aws.amazon.com/appconfig/latest/userguide/what-is-appconfig.html") is a capability of AWS Systems Manager, to create, manage, and quickly deploy application configurations. A _configuration_ is a collection of settings that influence the behavior of the application.

The [Amazon.Extensions.Configuration.SystemsManager](https://github.com/aws/aws-dotnet-extensions-configuration "https://github.com/aws/aws-dotnet-extensions-configuration") simplifies using [AWS AppConfig](https://docs.aws.amazon.com/appconfig/latest/userguide/what-is-appconfig.html "https://docs.aws.amazon.com/appconfig/latest/userguide/what-is-appconfig.html") as a source for configuration information for .NET applications.

# Microsoft.FeatureManagement

[Microsoft.FeatureManagement](https://github.com/microsoft/FeatureManagement-Dotnet "https://github.com/microsoft/FeatureManagement-Dotnet") provides standardized APIs for enabling feature flags within applications. This library secures a consistent experience when developing applications that use patterns such as beta access, rollout, dark deployments, and more.

# Configuration Sample

```json
"FeatureFlags": {
        "featureA": false,
        "featureB": true,
        "featureC": false,
        "featureD": {
            "EnabledFor": [
                {
                    "Name": "Microsoft.Targeting",
                    "Parameters": {
                        "Audience": {
                            "Users": [
                                "{tenantId}:{userId}",
                                "{tenantId}:{userId2}"
                            ],
                            "Groups": [
                                {
                                    "Name": "{tenantId}",
                                    "RolloutPercentage": 0
                                },
                                {

                                    "Name": "{tenantId2}",
                                    "RolloutPercentage": 50
                                },
                                {

                                    "Name": "{tenantId3}",
                                    "RolloutPercentage": 100
                                }
                            ],
                            "DefaultRolloutPercentage": 0
                        }
                    }
                }
            ]
        }
    }
```
