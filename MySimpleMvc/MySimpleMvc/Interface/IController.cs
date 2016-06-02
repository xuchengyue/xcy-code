using System.Web;

namespace MySimpleMvc.Interface
{
    public interface IController
    {
        //void Execute(HttpContext context);
        void Execute(HttpContextWrapper wrapper);
    }
}