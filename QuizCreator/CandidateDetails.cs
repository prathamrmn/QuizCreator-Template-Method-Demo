namespace QuizCreator
{
    /// <summary>
    /// Represents a quiz candidate's details.
    /// </summary>
    public class CandidateDetails
    {
        /// <summary>
        /// Gets the candidate's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the candidate's unique ID.
        /// </summary>
        public string CandidateID { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CandidateDetails"/> class.
        /// </summary>
        /// <param name="name">The candidate's name.</param>
        /// <param name="candidateID">The candidate's unique ID.</param>
        public CandidateDetails( string name , string candidateID )
        {
            Name = name;
            CandidateID = candidateID;
        }
    }
}

