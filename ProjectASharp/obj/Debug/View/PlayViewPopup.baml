   M S B A M L   `   `   `  ����C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjectA.ViewModelProjectA.ViewModel  5   	   !    ProjectA.View.PlayViewPopup   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /vm clr-namespace:ProjectA.ViewModel     5   	   -   5          �Name$  ThisView��5	   	    � Title$ PlayViewPopup��5   	   $	��720��6   $
��1280��6,    � WindowStartupLocation$ CenterScreen=�5	       � WindowStyle$
 None=�6B    � 
ResizeMode$ NoResize=�5
       � AllowsTransparency . 
������  � 	Resources 5      $   ProjectA.ViewModel.PlayPopupVM   PlayPopupVM��%   &	          5   
   6   5      .��5      �  � DataContext# [  6   ��5   
   �� 5       �� ImageSource$' !/View/Resources/PlayViewPopup.png��6   	 j� Stretch$	 UniformToFill=�6I   .+�5   
     -   5        
  Name$
 
xPersonNum��5      $��0,343,498,364q�6(   $��Right=�6?   ���	#FF0080FF$
��Bold"�6r   ��5      ��  �� Path$ 	NowPerson�   window 69   ��  �� ElementName$ ThisView��5   r   �� 5   
   $2��,앞에            명이 대기중입니다.��6   $��711,343,263,361q�64   $��Center=�6M   $	��306��6j   $��Center=�6v   � 5   
   $��10��6@   $	��362��6L   
����������	#FF4390FF$��614,328,304,382q�5   <    J� RenderTransformOrigin$ 0.5,0.5&�6U    � Maximum 5      �� $ InitialPersonNum� � Value 5      �� $ 	NowPerson�z�5      V� 5       .~�5!      �� �� 5"      �� 5#       �� Angle$	 180Q�6&   T� 5$      5%      5'      5(      5)      