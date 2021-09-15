using Microsoft.AspNetCore.Builder;

namespace ReadersAndBooks.Middleware
{
	public static class ExceptionHandlerExtensions
	{
		public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
		=> builder.UseMiddleware<ExceptionHandler>();
	}
}