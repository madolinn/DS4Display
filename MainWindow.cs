using System;
using System.Timers;
using Gtk;
using DS4Display;

public partial class MainWindow : Gtk.Window
{

	private static Timer loopTimer;
	static public JoyStick joyStick;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{

		joyStick = new JoyStick();

		loopTimer = new Timer(20);
		loopTimer.Elapsed += (sender, e) => MainLoop(sender, e, this);
		loopTimer.Start();

		Build();

		//buttonDebug.Text = DS4Display.MainClass.joyStick.getNumDevs().ToString();
		//buttonDebug.Text = DS4Display.MainClass.joyStick.getPos(1).dwXpos.ToString();

	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	public static void MainLoop(object source, ElapsedEventArgs e, MainWindow win)
	{

		var joyStickInputs = joyStick.getPos(0);
		var buttonsPressed = joyStickInputs.dwButtons;
		var DPad = joyStickInputs.dwPOV;

		win.buttonDebug.Text = joyStickInputs.dwZpos.ToString();

		win.buttonSquare.Visible = ((1 & buttonsPressed) == 1);
		win.buttonX.Visible = ((2 & buttonsPressed) == 2);
		win.buttonCircle.Visible = ((4 & buttonsPressed) == 4);
		win.buttonTriangle.Visible = ((8 & buttonsPressed) == 8);

		win.buttonR.Visible = ((32 & buttonsPressed) == 32);
		//win.buttonRT.Visible = (joyStickInputs.dwUpos > 100);
		win.buttonL.Visible = ((16 & buttonsPressed) == 16);
		//win.buttonLT.Visible = (joyStickInputs.dwVpos > 100);

		win.buttonStart.Visible = ((512 & buttonsPressed) == 512);
		win.buttonSelect.Visible = ((256 & buttonsPressed) == 256);

		win.buttonLeft.Visible = (DPad > 18000 && DPad < 36000);
		win.buttonDown.Visible = (DPad > 9000 && DPad < 27000);
		win.buttonRight.Visible = (DPad > 0 && DPad < 18000);
		win.buttonUp.Visible = (DPad != 65535 && (DPad > 27000 || DPad < 9000));

		win.buttonRightStick.Visible = (joyStickInputs.dwZpos != 32767);
		//win.buttonRightStick
		//((global::Gtk.Fixed.FixedChild)(win.fixed8[win.buttonStart])).X = (int)((joyStickInputs.dwZpos-32767)/2184);

		//Left Stick X-Axis, dwXpos +Right
		//Left Stick Y-Axis, dwYpos +Down

		//Right Stick X-Axis, dwZpos +Right
		//Right Stick Y-Axis, dwRpos +Down
	}

}
