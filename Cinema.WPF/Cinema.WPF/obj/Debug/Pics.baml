   M S B A M L   `   `   `  ����E  ACinema.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Cinema.WPF.ViewModelCinema.WPF.ViewModel  5   	       Cinema.WPF.Pics   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Cinema.WPF.ViewModel     5   	     � Title$
  Pics��5   	   $��564.476��6   $��756.857��6'    � DataContext 5	      (   "Cinema.WPF.ViewModel.PicsViewModel  5
   
   6    .��5      � .+�5   
   �� -   5         ��Name$ listBox1��5   �   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $
��Left=�6�   $	��184��6�   $��211,280,0,0q�6�   $	��Top=�6�   $	��343��6  ��6   �� *	Photoes+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6d   �� *SelP+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      ��  �� Padding$ 5,0,5,0q�6$   ��66   �� *	pathPhoto+$ PropertyChanged=�5      5      5      �� 5   
   $��0,0,0,10q�6   ��6+   �� *	Photoes+��5      �� 5      .R�5      �� $��0q�6!   .+�5      �� 	 ��Name$	 image��6c   $
��Left=�6r   $	��221��6�   $��	58,21,0,0q�6�   $	��Top=�6�   $	��626��6�   ��6    �� *	pathPhoto+$ PropertyChanged=�6�   5      5      5"      �� 5#   
   -   5        
 ��Name$
 button8��5#      $��35��6"   $	��Add��6.   $
��Left=�6V   $��
76,489,0,0q�6q   $	��Top=�6�   $	��193��6�   ��6<   �� *Add+6�   �� 5$   
   -   5        $
 button9��5$      $��35��6"   $��Delete��6.   $
��Left=�6[   $��476,489,0,0q�6v   $	��Top=�6�   $	��193��6�   ��6@   �� *Delete+6�   5&      5'      