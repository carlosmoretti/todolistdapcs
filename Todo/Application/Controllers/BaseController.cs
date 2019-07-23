using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Application.Controllers
{
    public enum EnumStatus
    {
        success, danger, warning
    }

    public class Notificacao
    {
        public EnumStatus status { get; set; }
        public string mensagem { get; set; }
    }

    public class BaseController : Controller
    {
    }

    public static class NotificationUtil
    {
        public static IHtmlContent Get(ITempDataDictionary tempdata)
        {
            string html = "";

            if (tempdata.Count != 0) { 
                Notificacao item = Newtonsoft.Json.JsonConvert.DeserializeObject<Notificacao>((string)tempdata["notificacao"]);
                html = $"<div class=\"alert alert-{item.status.ToString()}\">{item.mensagem}</div>";
            }

            return new HtmlContentBuilder().AppendHtml(html);
        }

        public static void Set(ITempDataDictionary tempData, Notificacao notificacao)
        {
            tempData["notificacao"] = Newtonsoft.Json.JsonConvert.SerializeObject(notificacao);
        }
    }
}