// extensions
//class __declspec(dllexport) Calc {
public ref class Calc {
protected:
  double sum;
  int    n;

public:
  Calc();
  ~Calc();
  // Finalizer
  !Calc();
  
  void Add(double number);

  double GetSum();
};
