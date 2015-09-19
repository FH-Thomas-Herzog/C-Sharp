#include <cstdio>
// #include "Calc.h"
#using "Calc.dll"

int main() {

   // Calc* calc = new Calc();
   Calc^ calc = gcnew Calc();
   
   calc->Add(5);
   calc->Add(10);
   calc->Add(15);
   calc->Add(20);
   
   printf("sum-%f\n", calc->GetSum());

   System::Console::WriteLine("Hello .NET");
   
   System::GC::Collect();
   
   delete calc;
}