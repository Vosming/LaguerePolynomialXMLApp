   M S B A M L   `   `   `  ����R  NZad1Tablicowaniefunkcji, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Zad1TablicowaniefunkcjiZad1Tablicowaniefunkcji  5   	   (    "Zad1Tablicowaniefunkcji.MainWindow   5   	   R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Zad1Tablicowaniefunkcji     5   	     � Title$  
MainWindow��5	   	   $	��650��6   $
��1200��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $&�� Enter Laguerre Polynomial Degree��6   $��	15,10,5,0q�5      �� 5   
   -   5         ��Name$ 	txtDegree��5      $��1��5      $	��200��5      $
��Left=�5      $��8,0,0,0q�5      ��5      �� *Degree+6*   �� 5   
   $)��#Enter alpha in generalized Laguerre��6   $��
240,10,5,0q�5       $
��Left=�5!      �� 5#   
   -   5        $ txtAlpha��5#      $��1��5$      $	��200��5%      $
��Left=�5&      $��	240,0,0,0q�5'      ��5(      �� *Alpha+�� 5*   
   $��1��6   $	��100��5+      $��460,10q�5,      $
��Left=�5-      $
��Show��5.      ��5/      �� *GeneratePromptCommand+�� 51   
   $��2��6   $
��Left=�53      $��5,5,5,5q�54      ��52      ��  �� Path$ Polmes�54      �� 56   
   -   5        $��Orthogonality��56      $"��Orthogonality Integral Value��58      $	��Top=�59      $��	5,10,25,5q�5:      $��Right=�5;      �� 5=   
   -   5        $��Enter_F_degrees��5=      $��Enter Function Degrees��5>      $��Center=�5?      $��0��5@      $��Right=�5A      $��	5,5,255,5q�5B      �� 5D   
   -   5        $��firstdegree��5D      $��1��5E      $��30��5F      $��Right=�5G      $��	5,5,335,5q�5H      ��5I      �� *FirstDegree+�� 5K   
   -   5        $��seconddegree��5K      $��1��5L      $��30��5M      $��Right=�5N      $��	5,5,265,5q�5O      ��5P      �� *SecondDegree+�� 5R   
   -   5        $��IntegralValue��5R      $��1��5S      $��Bottom=�5U      $��	5,10,90,5q�5V      $��Right=�5W      ��5T      �� $ 
Orthogonal�5W      �� 5X   
   -   5         ��Name$ OrthogonalButton��5X      $��1��5Y      $��Calc*��5Z      $��Right=�5[      $��50��5\      $��
5,10,175,5q�5]      $��Bottom=�5^      ��5_      �� *GenerateOrthogonalityCommand+�� 5a   
   -	   5        $ OrthogonalButton2��5a      $��1��5b      $��Calc**��5c      $��Right=�5d      $��50��5e      $��	5,10,25,5q�5f      $��Bottom=�5g      ��5h      �� *GenerateOrthogonalityCommand2+  OxyPlot.Wpf.PlotView  5k   
   -
   5          Name$ Plot1��5l      $��10q�5m      $��3��5n         Model 5o      �� *	PlotModel+5p      �� 5q   
   -   5        $ Draw_Pol��5q      $��4��5r      $��Draw Function��5s      $
��Left=�5t      $��
30,10,0,20q�5u      $��Bottom=�5v      ��5w      �� *GenerateChartCommand+�� 5x   
   -   5        $ Save_Pol��5x      $��4��5y      $��Save Function��5z      $��Right=�5{      $��10,10,30,20q�5|      $��Bottom=�5}      ��5~      �� *GenerateSaveFileCommand+5�      5�      