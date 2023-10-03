#region

using Contract.AWS;

#endregion

namespace Infrastructure.Common.Helpers;
public static class AwsCredentialsHelper
{
    private static string? CnnString;

    static AwsCredentialsHelper()
    {
        
#if DEBUG
        CnnString = "Host=localhost;Port=5432;Database=sge;Username=postgres;Password=Uala.123;";
        //CnnString = "Host=localhost;Port=5432;Database=credit_card;Username=postgres;Password=Uala.123;";
        //CnnString = "Host=localhost;Port=5432;Database=credit_card_arg;Username=postgres;Password=Uala.123;";
        //CnnString = "Host=creditcard.db.dev.credit-card.ar.wilobank.com;Port=5432;Database=credit_card;Username=adm_tc_user;Password=Nqt6k-RTQFz4-x&=";
        //CnnString = "Host=creditcard.db.stage.credit-card.ar.wilobank.com;Port=5432;Database=credit_card;Username=adm_tc_user;Password=Nqt6k-RTQFz4-x&=";
        //CnnString = "Host=creditcard-rds.stage.credit-card.mx.ua.la;Port=5432;Database=credit_card;Username=adm_tc_user;Password=MnLP8rde243@H674;";
        //CnnString = "Host=creditcard-rds.dev.credit-card.mx.ua.la;Port=5432;Database=credit_card;Username=adm_tc_user;Password=hHpa3#&3T3d6D9@q7;";
#else
        var cnnStringAux = System.Environment.GetEnvironmentVariable("RDS_STR_CONN");
        CnnString = cnnStringAux is not null ? (cnnStringAux + "Timeout=100;") : null;
#endif
    }

    public static async Task<string> GetRdsCnnString()
    {
        if (CnnString is not null)
            return CnnString;

        //var secretName = $"{Context.Env.ToLower()}/adp_rds_cnn";
        var secretName = $"dev/adp_rds_cnn";

        var secrets = await AwsSecretsHelper.GetSecrets<RdsSecrets>(secretName);

        CnnString = $"Host={secrets?.Host};Port={secrets?.Port};Database={secrets?.Database};Username={secrets?.Username};Password={secrets?.Password};Timeout=100;";
        
        return CnnString;
    }
}