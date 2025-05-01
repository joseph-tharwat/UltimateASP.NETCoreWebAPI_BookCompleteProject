using Microsoft.AspNetCore.Mvc.Formatters;
using Shared.DTOs;
using System.Text;

namespace CompanyEmployees.Formatter
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add("application/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            if(context.Object is CompanyDto)
            {
                CompanyDto company = (CompanyDto)context.Object;
                await context.HttpContext.Response.WriteAsync(company.ToString());
            }
            else
            {
                throw new BadHttpRequestException("type not supported");
            }
        }
    }
}
