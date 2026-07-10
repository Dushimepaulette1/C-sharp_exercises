namespace LearnReferences
{
  class Encyclopedia : Book, IFlippable
  {
    public int CurrentPage
    { get; set; }
    
    public Encyclopedia(int page = 0) : base()
    {
      CurrentPage = page;
    }

    public void Flip()
    {
      CurrentPage++;
    }

    public string Define()
    {
      return "Encyclopedia: a work that contains information on all branches of knowledge or comprehensively comprehensively covers a particular branch of knowledge, usually in articles arranged alphabetically by subject; often comes in multiple volumes.";
    }

    public override string Stringify() 
    {
      return "This is an Encyclopedia object!";
    }
  }
}