   M S B A M L   `   `   `  ����C  ?ProjectA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProjectA.ViewProjectA.View  5      7 clr-namespace:ProjectA.ViewModelProjectA.ViewModel  5      "    ProjectA.View.AppliedControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:ProjectA.View     5      /vm clr-namespace:ProjectA.ViewModel     5        � 	Resources  5
      $  ProjectA.ViewModel.IndexButton   IndexButton��%   &	          5   
   6   5      .��5      � ��5   
   �� 5       �� ImageSource$' !/View/Resources/AppliedClass2.png��6    j� Stretch$ UniformToFill=�6I   -   5        ClassControlColor��5   a    � ColumnDefinitions 5   
   �� 5      $��54 �6   �� 5      $	��130 �6   �� 5      $	��30* �6   �� 5      $	��43* �6   �� 5      $	��52* �6   �� 5      $	��43* �6   �� 5      $	��45* �6    � RowDefinitions 5   
   �� 5      $��21 �6   .+�5    
   �� -   5         ��Name$ 
xClassType��5       $��교양��6   $��Center=�5!      $��Center=�6%   �� 5"   
   -   5        $ 
xClassName��5"      $
��Name��6(   $��1��64   $��Center=�5#      $��Center=�61   �� 5$   
   -   5        $ 	xClassNum��5$      $��1��6'   $��2��60   $��Center=�5%      $��Center=�61   �� 5&   
   $��3학점��6   $��3��6    $��Center=�60   $��Center=�5'      �� 5(   
   -   5        $ xClassProfessor��5(      $��교수��6-   $��4��68   $��Center=�5)      $��Center=�61     5*   
   -   5          Name$ xApplyButton��5*   &   $��취소��6   $��6��6<    J� Opacity$ 0Q�6N   $��0,2,6,1q�5,   Y   ��5+      ��  �� Path$ CancleButtonCommand���5,      �� 	 �� ElementName$	 xApplyButton��$ ButtonIndex�6Y   5-      5.      