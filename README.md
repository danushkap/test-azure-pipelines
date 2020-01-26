# Test Azure DevOps Pipelines 

[![Azure DevOps builds](https://img.shields.io/azure-devops/build/danushkap/test-azure-pipelines/5?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_build/latest?definitionId=5)  [![Azure DevOps tests](https://img.shields.io/azure-devops/tests/danushkap/test-azure-pipelines/5?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_build/latest?definitionId=5)  [![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/danushkap/test-azure-pipelines/5?logo=azure-pipelines)](https://dev.azure.com/danushkap/test-azure-pipelines/_build/latest?definitionId=5)

[![GitHub license](https://img.shields.io/github/license/danushkap/test-azure-pipelines?style=flat&logo=github)](https://github.com/danushkap/test-azure-pipelines/blob/master/LICENSE) [![GitHub issues](https://img.shields.io/github/issues/danushkap/test-azure-pipelines?style=flat&logo=github)](https://github.com/danushkap/test-azure-pipelines/issues)

This project demontrate how Azure DevOps Pipilines can be used to impliment an E2E CI/CD pipipliens.

The .NET solution consit of:
1. ASP.NET Core MVC project `src/DemoWebApplication` 
1. Unit-test project that test a method in the MVC project `tests/DemoWebApplication.Tests`

### Continues Integration

In Azure DevOps, a build pipeline ([build.test-azure-pipelines](https://dev.azure.com/danushkap/test-azure-pipelines/_build?definitionId=5&_a=summary)) is configured for the porpose of CI.

This Pipiline can be executed, to build the `master`, `release` or any other brnach (in this GitHub repository). 

The build will:

* build the .NET solution (projects)
* publish the web content (to a folder)
* execute unit-tests
* calculate unit-test code covarage
* create a .nupkg having the published web content
* push the .nuget package to a NuGet feed

Based on the branch that get build:

* if `master` - will create a `Major`, `Minor` or `Hotfix` release and publish it to [Production NuGet Feed](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=feed&feed=Production)
* if `release` - will create a `Release Candidate` and publish it to [Production NuGet Feed](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=feed&feed=Production)
* any other - will create a `Pre-release` and publish it to [Development NuGet Feed](https://dev.azure.com/danushkap/test-azure-pipelines/_packaging?_a=feed&feed=Development)

Release chart:

Major Release | Minor Release | Hotfix | Release Candidate | Pre-release
--- | --- | --- | --- | ---

### Continues Dilivery

In Azure DevOps, there are two relase Pipiplnes created to deploy the sample web site

1. [prd_release.test-azure-pipelines](https://dev.azure.com/danushkap/test-azure-pipelines/_release?_a=releases&view=mine&definitionId=1) - to deploy a package from the Production NuGet Feed
1. [dev_release.test-azure-pipelines](https://dev.azure.com/danushkap/test-azure-pipelines/_release?_a=releases&view=mine&definitionId=2) - to deploy a package from the Development NuGet Feed

Deploying a relese will deploy the .nupkg to an Azure App Service with the URL: https://testazurepipelines.azurewebsites.net/
