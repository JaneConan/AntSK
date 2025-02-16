var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AntSK>("antsk");

builder.AddProject<Projects.AnyShareHandling>("anysharehandling");

builder.Build().Run();
