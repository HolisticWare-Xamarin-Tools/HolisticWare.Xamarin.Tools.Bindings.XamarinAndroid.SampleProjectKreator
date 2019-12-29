
Repositories = new Dictionary<string, Dictionary<string, string> >();

Task ("externals-download-code")
    .Does
    (
        () =>
        {
            Information("   externals-download-code ...");

            Repositories = Repositories
                                .Concat(Repositories_AndroidSupport)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                ;
            Repositories = Repositories
                                .Concat(Repositories_AndroidX)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                ;
            Repositories = Repositories
                                .Concat(Repositories_GooglePLayServices)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                ;
            Repositories = Repositories
                                .Concat(Repositories_Firebase)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                ;
            Repositories = Repositories
                                .Concat(Repositories_Material)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                ;

            EnsureDirectoryExists("../output");
            
            foreach(KeyValuePair<string, Dictionary<string, string> > repo_group in Repositories)
            {
                string path_repo_group = System.IO.Path.Combine(path_output_repos, repo_group.Key);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"    group dir  = {repo_group.Key}");

                EnsureDirectoryExists(path_repo_group);

                foreach(KeyValuePair<string, string> repo in repo_group.Value)
                {
                    string repo_git_url = $"{repo.Value}";
                    string repo_git_dir = $"{path_repo_group}/{repo.Key}";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"            repo_git_url = {repo_git_url}");
                    Console.WriteLine($"            repo_git_dir = {repo_git_dir}");

                    if (! DirectoryExists($"repo_git_dir"))
                    {
                        if (repo_git_url.EndsWith(".zip"))
                        {
                            Information($"            downloading .....");
                            DownloadFile
                                (
                                    repo_git_url,
                                    repo_git_dir
                                );
                        }
                        else if (repo_git_url.EndsWith(".git"))
                        {
                            Information($"        git clone .....");
                            GitClone
                                (
                                    repo_git_url,
                                    $"../output/{repo_git_dir}",
                                    new GitCloneSettings
                                    {
                                        RecurseSubmodules = true,
                                    }
                                );
                        }
                        else
                        {
                            try
                            {
                                repo_git_url = $"{repo_git_url}.git";
                                Information($"        git clone .....");
                                GitClone
                                    (
                                        repo_git_url,
                                        $"../output/{repo_git_dir}",
                                        new GitCloneSettings
                                        {
                                            RecurseSubmodules = true,
                                        }
                                    );
                            }
                            catch (System.Exception)
                            {
                                Error($"Could not clone: {repo_git_url}");
                            }
                        }
                    }


                }
            }
            Console.ResetColor();

            return;
        }
    );

Task("externals-update-git-repos")
.Does
(
    () =>
    {
		// https://stackoverflow.com/questions/42918647/need-to-get-the-details-of-the-modified-files-in-gitpull-method-in-cake-script


        foreach (KeyValuePair<string, Dictionary<string, string> > repo_group in Repositories)
        {

			if (DirectoryExists(repo_group.Key))
			{
				Warning ($"       Folder exists ../{repo_group.Key}");
				Warning ($"       git pull ../{repo_group.Key}");
				string directory = System.IO.Path.Combine("..", repo_group.Key);

				exitCodeWithArgument =
										StartProcess
										(
											"git",
											new ProcessSettings
											{
												Arguments = $"-C ../{repo_group.Key} pull",
												RedirectStandardOutput = true
											},
											out redirectedStandardOutput
										);

				string git_pull = string.Join(Environment.NewLine, redirectedStandardOutput);

				Information($"git pull: {git_pull}");
				Information($"          {git_pull}");

				GitMergeResult result = GitPull
											(
												directory, git_user, git_email
											);

				if (result.Status == GitMergeStatus.UpToDate)
				{
		            Information($"         dir  = ../{repo_group.Key}");
		            Information($"            up to date");
				}
				else
				{
		            Error($"         dir  = ../{repo_group.Key}");
		            Error($"            dirty - commit or stash");
				}
			}
			else
			{
                foreach(KeyValuePair<string, string> kvp in repo_group.Value)
                {

                }
				// exitCodeWithArgument =
				// 						StartProcess
				// 						(
				// 							"git",
				// 							new ProcessSettings
				// 							{
				// 								Arguments = $"-C {repo.Key.Folder} clone",
				// 								RedirectStandardOutput = true
				// 							},
				// 							out redirectedStandardOutput
				// 						);

				string git_pull = string.Join(Environment.NewLine, redirectedStandardOutput);
				Information($"git email: {git_pull}");
			}
        }

        return;
    }
);

