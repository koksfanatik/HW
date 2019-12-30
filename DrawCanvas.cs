using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace DrawAndroid
{
    public class DrawCanvas : View, INotifyPropertyChanged



    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _sliderValue;
        public int sliderValue
         {
            get { return _sliderValue; }
            set
            {       _sliderValue = value;
                    OnPropertyChanged("sliderValue");
            }

        }
        private int _buttonValue;
        public int buttonValue
        {
            get { return _buttonValue; }
            set
            {
                _buttonValue = value;
                OnPropertyChanged("sliderValue");
            }

        }

        public int hight;
        public int width;
        public void OnPropertyChanged(string prop)
        {
            this.Invalidate();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

            }
        }


        public DrawCanvas(Context context) : base(context)
        {
        }

        public DrawCanvas(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public DrawCanvas(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public DrawCanvas(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        protected DrawCanvas(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            float rectHight = (float)(this.hight * 0.9);
            float rectWidth = (float)(this.width / 3);
            float barHight = (float)(rectHight / 13);
            Paint textPaint = new Paint();
            textPaint.Color = Color.White;
            textPaint.StrokeWidth = 10;
            textPaint.TextSize = (float)(this.hight * 0.1) + 10;
            textPaint.TextAlign = Paint.Align.Center;
            Paint rectPaint = new Paint();
            
            
            switch (buttonValue)
            {
                case 1:
                    rectPaint.Color = Color.Blue;
                    rectPaint.SetStyle(Paint.Style.Fill);
                    canvas.DrawRect(rectWidth, (this.hight - (float)(rectHight * ((float)sliderValue / 100))), rectWidth * 2, this.hight, rectPaint);
                    rectPaint.Color = Color.Red;
                    rectPaint.SetStyle(Paint.Style.Stroke);
                    rectPaint.StrokeWidth = 10;
                    canvas.DrawRect(rectWidth, (this.hight - (float)(rectHight * ((float)sliderValue / 100))), rectWidth * 2, this.hight, rectPaint);
                    canvas.DrawText(sliderValue.ToString()+"%", (float)(rectWidth * 1.5), (this.hight - (float)(rectHight * ((float)sliderValue / 100))), textPaint);
                    break;
                case 2:
                    for (int i = 0; i < (sliderValue / 10); i++)
                    {
                        rectPaint.Color = Color.Blue;
                        rectPaint.SetStyle(Paint.Style.Fill);
                        canvas.DrawRect(rectWidth, this.hight - barHight - i * (barHight + barHight / 3), rectWidth * 2, this.hight - i * (barHight + barHight / 3), rectPaint);
                        rectPaint.Color = Color.Red;
                        rectPaint.SetStyle(Paint.Style.Stroke);
                        rectPaint.StrokeWidth = 10;
                        canvas.DrawRect(rectWidth, this.hight - barHight - i * (barHight + barHight / 3), rectWidth * 2, this.hight - i * (barHight + barHight / 3), rectPaint);
                    }
                    canvas.DrawText(sliderValue.ToString()+"%", (float)(rectWidth * 1.5), this.hight - (sliderValue / 10) * (barHight + barHight / 3), textPaint);
                    break;
                case 3:
                    rectPaint.Color = Color.Blue;
                    rectPaint.SetStyle(Paint.Style.Stroke);
                    rectPaint.StrokeWidth = 50;
                    canvas.DrawArc(100, 100, Math.Min(this.width, this.hight) - 100, Math.Min(this.width, this.hight) - 100, 0, 360 * (float)sliderValue / 100, false, rectPaint);
                    canvas.DrawText(sliderValue.ToString()+"%", Math.Min(this.width, this.hight)/2, Math.Min(this.width, this.hight)/2, textPaint);
                    break;
                
            }
        }
        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
            hight = bottom - top;
            width = right - left;
            
        }
    }
}
   

