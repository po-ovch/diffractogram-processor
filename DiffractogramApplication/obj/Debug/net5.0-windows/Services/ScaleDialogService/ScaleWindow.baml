   M S B A M L   `   `   `  ����S  ODiffractogramApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:DiffractogramApplicationDiffractogramApplication  5   	   F    @DiffractogramApplication.Services.ScaleDialogService.ScaleWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8local&clr-namespace:DiffractogramApplication     5   	     � Title$  	Set scale��5   	    � SizeToContent$ WidthAndHeight=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $
��Auto �6   .+�5   
   �� Min X value6!   �� 5   
   -   5        $��	StartXStr��5      $��1��6#   $	��250��60   �� 5   
   $��2��6   Max X value6.   �� 5   
   -   5        $��	StartYStr��5      $��3��6#   $	��250��60   �� 5   
   $��4��6   Min Y value6.   �� 5   
   -   5        $��EndXStr��5      $��5��6!   $	��250��6.   �� 5   
   $��6��6   Max Y value6.   �� 5    
   -   5        $��EndYStr��5       $��7��6!   $	��250��6.   � 5"   
   $��8��6   $��Right=�6!   $��0,15,0,0q�6=   .+�5#      �� -   5         �� 	IsDefault$
 True��5#      $��60��6:   $��0,0,10,0q�6H   .��6Z   OK6^   �� 5$       �� IsCancel$
 True��6   $��60��6%   .��63   Cancel6;   5%      5'      5(      