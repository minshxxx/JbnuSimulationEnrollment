   M S B A M L   `   `   `  ����C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectA.ViewModelProjectA.ViewModel  5      K*clr-namespace:ProjectA.ViewModel.ConverterProjectA.ViewModel.Converter  5      G(clr-namespace:ProjectA.ViewModel.CommandProjectA.ViewModel.Command  5          ProjectA.View.WaitView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /vm clr-namespace:ProjectA.ViewModel     5      9cv*clr-namespace:ProjectA.ViewModel.Converter     5      7cm(clr-namespace:ProjectA.ViewModel.Command     5      -   5          N�Name$  ThisView��5
   1    N� Title$ ThisView��5       � 	Resources 5        ProjectA.ViewModel.WaitVM 
  WaitVMA  ;ProjectA.ViewModel.Converter.MultiCommandParameterConverter  CV*   $ProjectA.ViewModel.Command.UICommand  	UICommand��%W   &	        &	      &	 &       5   
   6     5   
   6,     5   
   6   5      .��5      � ��5   
   �� 5       �� ImageSource$" /View/Resources/WaitView.png��6    j� Stretch$ UniformToFill=�6D    � RowDefinitions 5   
   �� 5      $��18 �6   �� 5      $��45 �6   �� 5      $��33 �6   �� 5      $��37 �6   �� 5      $	��18* �6   �� 5      $	��65* �6   �� 5      $	��26* �6   �� 5      $	��52* �6   �� 5       $��6* �6   �� 5!      $
��125* �6   �� 5"      $
��259* �6   �� 5#      $	��36* �6    � ColumnDefinitions 5%   
   �� 5&      $	��250 �6   �� 5'      $	��265 �6   �� 5(      $	��177 �6   �� 5)      .+�5-   
   �� -   5         ��Name$ ToPlay��5-       J� Opacity$ 0Q�6!   $��2��6-   $��1��6=   ��5.      �� 	 �� Source#	 [ ��5/      `� 50      
 `� 	Converter#
 [ 6   .1�51      ��  �� Path$
 Name�6    �� ElementName$ ToPlay��6*   �� 52      $ ThisView��6   53      55      �� 58   
   -   5         ��Name$ lblTime��58      $��70(�6!   
�������$��0��59      $��3��5;      $��82��6!   $��Center=�6-   $	��Top=�5<      $	��226��6(   $4��./ProjectA;component/View/Resources/#DS-Digital)�5=      $��
14,23,10,0q�5>      $��1��6$   ��5:      �� #	 [  $ NowClock�5>   $   �� 5@   
   -   5         ��Name$ 	xUserName��5@      $��	민성환��6'   $��3��5A      $��314,0,238,4q�6$    �� TextAlignment$ Right=�69   ���	#FFFFD1006O   �� 5D   
   $��5��6   $��48,0,0,0q�5E      $	��461��6   $��Bottom=�6%   $��6��6@   $	��202��6Q   .+�5F      �� $��0,1,0,0q�6a   ��6   �� #	 [  $ GoalList�6a   5G      5H      5I      