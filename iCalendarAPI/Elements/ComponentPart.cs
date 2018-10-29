namespace ICalendarAPI.Elements
{

	public class ComponentPart
	{
		public string Name { get; set; }
		public object Value { get; set; }
		
		internal ComponentPart(string name, object value)
		{
			Name = name;
			Value = value;
		}

		public override string ToString()
		{
			return $"{Name}={Value}" ;
		}
	}
}
