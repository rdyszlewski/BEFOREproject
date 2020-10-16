public interface IRoundSelection{

  void Initialize(PatternItem pattern);
  void Select(int turn, int step);
  void Deselect(int turn, int step); // TODO: zastanowić się 
}