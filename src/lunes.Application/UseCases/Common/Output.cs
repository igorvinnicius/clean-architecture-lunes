using System.Collections.Generic;
using System.Linq;

namespace lunes.Application.UseCases.Common
{
    public class Output
    {
	    protected List<string> Errors { get; set; } = new List<string>();

	    protected bool HasErrors  => Errors.Any();

	    protected void AddError(string error)
	    {
			Errors.Add(error);
	    }

	    protected void AddErrors(List<string> errors)
	    {
		    Errors.AddRange(errors);
	    }

	}
}
