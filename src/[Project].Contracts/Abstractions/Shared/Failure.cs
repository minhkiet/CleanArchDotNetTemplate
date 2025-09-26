﻿namespace _Project_.Contracts.Abstractions.Shared;

public class Failure : Result
{
    public IReadOnlyList<Error> Errors { get; }

    internal Failure(IEnumerable<Error> errors)
    {
        IsSuccess = false;
        Errors = [.. errors];
    }

    internal Failure(Error error)
        : this([error]) { }
}