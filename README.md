What is gitlab-ci.net?
=============

*gitlab-ci.net* is a .NET REST client implementation of the GitLab Ci API with no external dependencies.

Usage
=============

It's a wrapper of the REST api. Read the [GitLab docs](https://github.com/gitlabhq/gitlab-ci/tree/master/doc/api) and start using by 

Creating a GitLabCiClient instance:

```csharp

var client =  GitLabCiClient.Connect("https://mygitlab-ci.example.com", "https://mygitlab.example.com", "your_private_token");
```

Then use its properties. You can obtain the private token in your account page. You may want to create a custom user for the API usage.

Listing all the projects:

```csharp

  string _gitlabCiUrl = "https://ci.example.com";
  string _gitlabUrl  = "https://gitlab.example.com";
  string _token = "XXXXXX-XXXXXXXXXXXXX";

  // Disabling SSL certificate validation is your gitlab-ci server uses self-signed certificates
  ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

  GitLabCiClient client = null;
  try
  {
    Console.WriteLine("Connecting to \"{0}\"", _gitlabCiUrl);
    client = GitLabCiClient.Connect(_gitlabCiUrl, _gitlabUrl, _token);
    Console.WriteLine("Listing projects");
    foreach (Project project in client.Projects.All)
    {
      Console.WriteLine(project);
    }
  }
  catch (Exception ex)
  {
    Console.WriteLine("Error connecting to \"{0}\": {1}", _gitlabCiUrl, ex.Message);
    return -1;
  }
```

Nuget
=============

Get it from NuGet. You can simply install it with the Package Manager console:
    
    PM> Install-Package gitlab-ci.net

Status
=============
*gitlab-ci.net* currently only supports Projects listing / creation but it is very easy to extend. It me up if you need anything added. Won't take me long to respond.

Credits
=============

This library is heavily derived from the very well designed [NGitlab](https://github.com/Scooletz/NGitLab) .NET wrapper for the Gitlab API by @Scooletz.

Licence
=============

gitlab-ci.net is licensed under the Apache 2.0 License, see LICENSE for more information.
