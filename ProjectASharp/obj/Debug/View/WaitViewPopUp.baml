   M S B A M L   `   `   `  ����C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectA.ViewModelProjectA.ViewModel  5   	   G(clr-namespace:ProjectA.ViewModel.CommandProjectA.ViewModel.Command  5   	   K*clr-namespace:ProjectA.ViewModel.ConverterProjectA.ViewModel.Converter  5   	   !    ProjectA.View.WaitViewPopUp   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /vm clr-namespace:ProjectA.ViewModel     5   	   7cm(clr-namespace:ProjectA.ViewModel.Command     5   	   9cv*clr-namespace:ProjectA.ViewModel.Converter     5   	   -   5          �Name$  ThisView��5   	    � Title$ WaitViewPopUp��5
   	   $	��720��6   $
��1280��6,    � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�6B    � 
ResizeMode$ NoResize=�5       � AllowsTransparency . 
������  � 	Resources 5      A  ;ProjectA.ViewModel.Converter.MultiCommandParameterConverter   CV*   $ProjectA.ViewModel.Command.UICommand  	UICommand��%:   &	        &	        5   
   6,     5   
   6   5      .��5      � ��5   
   �� 5       �� ImageSource$' !/View/Resources/WaitViewPopUp.png��6    j� Stretch$ UniformToFill=�6I   .+�5   
   �� -   5        	 ��Name$	 ToExit��5      
 J� Opacity$
 0Q�6!   ��5      ��  �� Source# [ ��5      `� 5       `� 	Converter# [  6   .1�5      ��  �� Path$
 Name�6    �� ElementName$ ToExit��6*   �� 5      $ ThisView��6   5      5!      5"      5#      