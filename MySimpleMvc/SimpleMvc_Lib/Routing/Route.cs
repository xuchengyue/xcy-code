using System.Collections.Generic;

namespace SimpleMvc_Lib.Routing
{
    public class Route
    {
        public Route(string urlTemplate, object defaults)
        {
            this.UrlTemplate = urlTemplate;
            Defaults = new Dictionary<string, string>();
            var pros = defaults.GetType().GetProperties();
            foreach (var item in pros)
            {
                Defaults.Add(item.Name, item.GetValue(defaults).ToString());
            }
        }

        public string UrlTemplate { get; set; }

        public Dictionary<string, string> Defaults { get; set; }

        public bool MatchUrl(string requestUrl, out IDictionary<string, string> routeData)
        {
            routeData = new Dictionary<string, string>();
            foreach (var item in Defaults)
            {
                routeData.Add(item.Key, item.Value);
            }

            var requestItems = requestUrl.Split('/');
            var urlTemplateItems = UrlTemplate.Split('/');

            if (requestItems.Length != urlTemplateItems.Length)
            {
                return false;
            }

            for (int i = 0; i < urlTemplateItems.Length; i++)
            {
                //string key = urlTemplateItems[i];
                //routeData[key] = requestItems[i];
                var requestItem = requestItems[i];
                var templateItem = urlTemplateItems[i];

                if (templateItem.StartsWith("{") && templateItem.EndsWith("}"))
                {
                    string key = templateItem.Trim("{}".ToCharArray());
                    if (routeData.ContainsKey(key) && !string.IsNullOrEmpty(requestItem))
                    {
                        routeData[key] = requestItem;
                    }
                }
                else
                {
                    if (!templateItem.Equals(requestItem, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        routeData.Clear();
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
