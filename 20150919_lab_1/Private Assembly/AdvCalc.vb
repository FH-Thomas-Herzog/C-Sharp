

Public Class AdvCalc
	Inherits Calc
	
	Public Function GetAverage() As Double
	
		If (n > 0) Then
			return sum / n
		Else 
			return 0
		End If
	
	End Function

End Class