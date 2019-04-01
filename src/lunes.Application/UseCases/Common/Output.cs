using System.Collections.Generic;

namespace lunes.Application.UseCases.Common
{
    public class Output
    {
	    protected IList<string> Errors { get; private set; }

	    public Output()
	    {
		    Errors = new List<string>();
	    }

		public Output(IList<string> errors)
	    {
		    Errors = errors;
	    }
    }
}
