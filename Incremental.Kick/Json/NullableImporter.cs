namespace Incremental.Kick.Json
{
    #region Imports

    using System;
    using Jayrock.Json;
    using Jayrock.Json.Conversion;

    #endregion

    /// <summary>
    /// Adds support for importing nullable value types (<see cref="Nullable{T}"/>)
    /// from JSON data.
    /// </summary>

    public sealed class NullableImporter<T> : IImporter
        where T : struct 
    {
        public Type OutputType
        {
            get { return typeof(T?); }
        }

        public object Import(ImportContext context, JsonReader reader)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (reader == null) throw new ArgumentNullException("reader");

            if (!reader.MoveToContent())
                throw new JsonException("Unexpected EOF.");

            if (reader.TokenClass == JsonTokenClass.Null)
            {
                reader.Read();
                return null;
            }

            return context.Import(typeof(T), reader);
        }
    }
}
