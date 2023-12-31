﻿using System.Collections;
using System.Net;

namespace FileEx.Client;

public interface IFileService
{
    public Task<IEnumerable<string>> GetDirectory(string path);

    public Task<HttpStatusCode> HealthCheck();
}
