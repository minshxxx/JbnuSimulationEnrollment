   M S B A M L   `   `   `  ����C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectA.ViewModel.ConverterProjectA.ViewModel.Converter  5      G(clr-namespace:ProjectA.ViewModel.CommandProjectA.ViewModel.Command  5      7 clr-namespace:ProjectA.ViewModelProjectA.ViewModel  5          ProjectA.View.ResultView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9cv*clr-namespace:ProjectA.ViewModel.Converter     5      7cm(clr-namespace:ProjectA.ViewModel.Command     5      /vm clr-namespace:ProjectA.ViewModel     5      -   5          N�Name$  ThisView��5       N� Title$ 
ResultView��6    � 	Resources 5      !  ProjectA.ViewModel.ResultVM   ResultVMA  ;ProjectA.ViewModel.Converter.MultiCommandParameterConverter  CV*   $ProjectA.ViewModel.Command.UICommand  	UICommand��%W   &	        &	      &	 &       5   
   6     5   
   6,     5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��204 �6   �� 5      $	��111 �6   �� 5      $	��200 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $	��65* �6   �� 5      $	��94* �6   �� 5      $	��96* �6   �� 5       $
��178* �6   �� 5!      $	��82* �6   �� 5"      $
��515* �6   ��5%   
   �� 5&       �� ImageSource$$ /View/Resources/ResultView.png��6    j� Stretch$ UniformToFill=�5'      .+�5+   
   �� $��1��6   $	��408��6"   $��Bottom=�6/   $��6��6J   $��108,0,0,108q�5,      $��3��6*   .+�5-      �� ��6   ��  �� Source# [   �� Path$ GoalList�5.      �� 50   
   $��성공한 과목 수��6   $��4��6$   $��1��64   $��0,0,0,83q�51      $
��Bold"�6&   $��20(�68   
�������$��Bottom=�6Y   $��Right=�6t   $��26��6�   $	��134��6�   	 J� RenderTransformOrigin$	 
0.56,0.444&�6�   �� 54   
   $��4��55      $��1��6$   $��Bottom=�56      $��30(�6/   $
��Bold"�57      
�������$��Right=�69   $	 0.5,0.5&�58      $��0,0,0,23q�64   $	��134��6F   $��56��6R   
 �� TextAlignment$
 Right=�6^   ��54      �� # [  $ 
CorrectNum�58   ^   �� 5;   
   -   5         ��Name$ ToExit��5;       J� Opacity$ 0Q�6!   $��68,120,75,24q�5=      $��3��6'   ��5<      �� # [ ��5>      `� 5?       `� 	Converter# [ 6   .1�5@      �� $
 Name�6    �� ElementName$ ToExit��6*   �� 5A      $ ThisView��6   5B      5D      �� 5G   
   -   5        $ ToRecord��5G      $ 0Q�6#   $��
32,1,5,148q�5I      $��2��6%   ��5H      �� # [ ��5J      `� 5K      # [ 6   .1�5L      �� $
 Name�6   $ ToRecord��6*   �� 5M      $ ThisView��6   5N      5P      �� 5S   
   -   5        $ ToReady��5S      $ 0Q�6#   $��
32,17,0,44q�5U      $��1��6%   ��5T      �� # [ ��5V      `� 5W      # [ 6   .1�5X      �� $
 Name�6   $ ToReady��6*   �� 5Y      $ ThisView��6   5Z      5\      �� 5_   
   $��3��5`      $��60(�6#   
�������$��Bottom=�6D   $��Right=�5a      $	 
0.56,0.444&�6/   $��	0,0,0,109q�5b      $��2��6&   $��2��6:   $4��./ProjectA;component/View/Resources/#DS-Digital)�5c      $	��209��6O   $
 Right=�6[   $��65��6q   ��5_      �� *
ResultTime+# [  5c   q   �� 5f   
   $��52(�6T   ���	#FFFFB900$��Bottom=�5g   +   $
��Left=�5h      $	 
0.56,0.444&�5i      $��	10,0,0,10q�67   $��6��5j      $��3��6(   $��1��65   $��Yu Gothic UI)�6E   $
��Bold"�6_   $
��1010��6q   ��5f      �� # [  $ Comment�5j   q   �� 5k   
   $��종료시각��6   $��4��6    $��2��60   $��	0,0,0,174q�5l      $
��Bold"�6    $��20(�62   
�������$��Bottom=�6S   $��Right=�6n   $��26��6�   $	��134��6�   $	 
0.56,0.444&�6�   $
 Right=�6�   5n      5o      