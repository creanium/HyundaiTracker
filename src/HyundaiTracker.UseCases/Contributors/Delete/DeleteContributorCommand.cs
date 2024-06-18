﻿using Ardalis.Result;
using Ardalis.SharedKernel;

namespace HyundaiTracker.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
