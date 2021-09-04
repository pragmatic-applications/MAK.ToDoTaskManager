using Constants;

namespace Domain
{
    public class UrlHelper
    {
        public static string GetImagePath() => DeployedState.IsDeployed ? ApiUrl.ServerApiImageUrl : HttpConstant.Api_Image_Path;
    }
}
