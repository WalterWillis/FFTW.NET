using System;
using System.Collections.Generic;
using System.Text;

namespace FFTW.NET
{
	public enum DftDirection : int
	{
		Forwards = -1,
		Backwards = 1
	}

	[Flags]
	public enum PlannerFlags : uint
	{
		Default = Measure,
		/// <summary>
		/// <see cref="Measure"/> tells FFTW to find an optimized plan by actually
		/// computing several FFTs and measuring their execution time.
		/// Depending on your machine, this can take some time (often a few seconds).
		/// </summary>
		Measure = (0U),
		/// <summary>
		/// <see cref="Exhaustive"/> is like <see cref="Patient"/>,
		/// but considers an even wider range of algorithms,
		/// including many that we think are unlikely to be fast,
		/// to produce the most optimal plan but with a substantially increased planning time. 
		/// </summary>
		Exhaustive = (1U << 3),
		/// <summary>
		/// <see cref="Patient"/> is like <see cref="Measure"/>,
		/// but considers a wider range of algorithms and often produces
		/// a “more optimal” plan (especially for large transforms),
		/// but at the expense of several times longer planning time
		/// (especially for large transforms). 
		/// </summary>
		Patient = (1U << 5),
		/// <summary>
		/// <see cref="Estimate"/> specifies that,
		/// instead of actual measurements of different algorithms,
		/// a simple heuristic is used to pick a (probably sub-optimal) plan quickly.
		/// With this flag, the input/output arrays are not overwritten during planning.
		/// </summary>
		Estimate = (1U << 6),
		/// <summary>
		/// <see cref="WisdomOnly"/> is a special planning mode in which
		/// the plan is only created if wisdom is available for the given problem,
		/// and otherwise a <c>null</c> plan is returned. This can be combined
		/// with other flags, e.g. '<see cref="WisdomOnly"/> | <see cref="Patient"/>'
		/// creates a plan only if wisdom is available that was created in
		/// <see cref="Patient"/> or <see cref="Exhaustive"/> mode.
		/// The <see cref="WisdomOnly"/> flag is intended for users who need to
		WisdomOnly = (1U << 21)
	}

}