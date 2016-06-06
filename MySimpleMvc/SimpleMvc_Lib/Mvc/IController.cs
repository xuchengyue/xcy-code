
namespace SimpleMvc_Lib.Mvc
{
    public interface IController
    {
        ActionResult Execute(RequestContext context);
    }
}
