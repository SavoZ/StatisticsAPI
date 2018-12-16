using System;
using System.Collections.Generic;
using System.Text;

namespace StatisticsService.Parser {
	public interface IParser<T> where T : class {
		//ILog Log { get; }
		List<T> Records { get; }
		void Parse(String json);
	}
}
