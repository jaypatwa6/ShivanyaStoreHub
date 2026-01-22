namespace SSH.Framework.CQRS.SharedModels
{
    public enum ServiceReturnCode
    {
        Success = 0,
        InvalidInputData = 1,
        FailedBusinessValidation = 2,


        UnauthenticatedUser = 0x10,
        UnauthorizedAccess = 0x20,
        UnknownError = 0xff
    }
}
