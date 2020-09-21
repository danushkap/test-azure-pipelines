# Test Azure DevOps Pipelines 

[![GitHub license](https://img.shields.io/github/license/danushkap/test-azure-pipelines?style=flat&logo=github)](https://github.com/danushkap/test-azure-pipelines/blob/master/LICENSE) [![GitHub issues](https://img.shields.io/github/issues/danushkap/test-azure-pipelines?style=flat&logo=github)](https://github.com/danushkap/test-azure-pipelines/issues)

This project demonstrate how Azure DevOps Pipelines can be used to;
1. [CI] build a .NET solution having a very basic ASP.NET Core MVC website 
1. [CD] deploy the site to an `Azure App Service` with the URL: 

https://testazurepipelines.azurewebsites.net/ [![Azure App Service](https://img.shields.io/website?down_message=offline&label=App%20Service&logo=microsoft-azure&logoColor=white&up_message=online&url=https%3A%2F%2Ftestazurepipelines.azurewebsites.net%2F)](https://testazurepipelines.azurewebsites.net/)

The .NET solution `DemoWebApplication.sln` consist of:
1. ASP.NET Core MVC project `src/DemoWebApplication` 
1. xUnit test project `tests/DemoWebApplication.Tests`

Latest CI/CD status: 

[![Azure DevOps builds](https://img.shields.io/azure-devops/build/danushkap/test-azure-pipelines/5?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_build/latest?definitionId=5)  [![Azure DevOps tests](https://img.shields.io/azure-devops/tests/danushkap/test-azure-pipelines/5?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_build/latest?definitionId=5)  [![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/danushkap/test-azure-pipelines/5?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_build/latest?definitionId=5)  [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.2.0-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.2.0&protocolType=NuGet)  [![Azure DevOps Releases](https://img.shields.io/badge/Release--1.2.0-deployed-success?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_releaseProgress?releaseId=61)

### Continues Integration

For this propose, in Azure DevOps a build pipeline - [build.test-azure-pipelines](https://dev.azure.com/danushkap/test-azure-pipelines/_build?definitionId=5&_a=summary) - is configured.

This Pipeline can be executed, to build the `master`, `release` or any other branch in this repository. 

And the build will:

* build the .NET solution (projects)
* publish the web content (to a folder)
* execute the unit-tests
* calculate unit-test code coverage
* create a .nupkg having the published web content
* push the .nuget package to a NuGet feed

Based on the branch that get build, i.e.:

* `if {branch} = master` then a `Major`, `Minor` or `Hotfix` package will be published to [Production NuGet Feed](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=feed&feed=Production)
* `if {branch} = release` then a `Release Candidate` package will be published to [Production NuGet Feed](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=feed&feed=Production)
* `if {branch} = {any other}` then a `Preview` package will be published to [Development NuGet Feed](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=feed&feed=Development)

<br>

#### Package Version History | Semantic Versioning: `semver-2.0.0`

Major Release | Minor Release | Hotfix | Release Candidate | Preview
--- | --- | --- | --- | ---
<i></i> | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.2.0-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.2.0&protocolType=NuGet)
<i></i> | | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.2.0--rc.1-yellow?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.2.0-rc.1&protocolType=NuGet)
<i></i> | | | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.2.0--Branch.develop.Sha.575332c-yellow?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Development&package=DemoWebApplication&version=1.2.0-develop.575332c&protocolType=NuGet)
<i></i> | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.1.0-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.1.0&protocolType=NuGet)
<i></i> | | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.1.0--rc.2-yellow?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.1.0-rc.2&protocolType=NuGet)
<i></i> | | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.1.0--rc.1-yellow?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.1.0-rc.1&protocolType=NuGet)
<i></i> | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.0.3-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.0.3&protocolType=NuGet)
<i></i> | | | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.1.0--Branch.develop.Sha.8d5bd4d-yellow?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Development&package=DemoWebApplication&version=1.1.0-develop.8d5bd4d&protocolType=NuGet)
<i></i> | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.0.2-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.0.2&protocolType=NuGet)
<i></i> | | | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.1.0--Branch.featurex.Sha.6bc3e69-yellow?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Development&package=DemoWebApplication&version=1.1.0-featureX.6bc3e69&protocolType=NuGet)
<i></i> | | [![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.0.1-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.0.1&protocolType=NuGet)
[![Azure DevOps Artifact](https://img.shields.io/badge/NuGet-1.0.0-informational?logo=azure-artifacts)](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=package&feed=Production&package=DemoWebApplication&version=1.0.0&protocolType=NuGet)

<br>

### Continues Delivery

In Azure DevOps, there are two release Pipelines created to deploy the web site to the `Azure App Service`:

1. [prd_release.test-azure-pipelines](https://dev.azure.com/danushkap/test-azure-pipelines/_release?_a=releases&view=mine&definitionId=1) - to deploy a package from the Production NuGet Feed
1. [dev_release.test-azure-pipelines](https://dev.azure.com/danushkap/test-azure-pipelines/_release?_a=releases&view=mine&definitionId=2) - to deploy a package from the Development NuGet Feed

And deploying a release in the pipeline will deploy the .nupkg assigned to that release to the `Azure App Service`.
