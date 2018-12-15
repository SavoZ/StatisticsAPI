using System;
using System.Collections.Generic;
using System.Text;

namespace StatisticsService.Parser {
	public abstract class Parser<T> : IParser<T> where T : class {

		//private ILog _log;
		private List<T> _records;
		//public ILog Log { get { return _log; } }
		public List<T> Records { get { return _records; } }

		public Parser() {
			_records = new List<T>();
			//_log = LogManager.GetLogger(GetType());
			//XmlConfigurator.Configure();
		}

		public virtual void Parse(String json) {
			throw new NotImplementedException();
		}
	}
}
