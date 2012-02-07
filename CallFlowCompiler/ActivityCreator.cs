/******************************************************************************************
 * 
 * Copyright (c) 2012 WU WAI FAN DENNIS
 * 
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software 
 * is furnished to do so, subject to the following conditions:
 * 
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN 
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
******************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Interaction.Compiler
{
    public class ActivityCreator
    {
        private static ActivityCreator _self = null;

        private ActivityCreator()
        {
        }

        public static ActivityCreator Instance
        {
            get
            {
                if (_self == null)
                {
                    _self = new ActivityCreator();
                }

                return _self;
            }
        }

        public IActivity CreateInstance(string strActivity)
        {
            IActivity ret = null;

            if (strActivity.ToUpper() == "START")
            {
                ret = new StartActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "ANSWER")
            {
                ret = new AnswerActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "HANGUP")
            {
                ret = new HangupActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "SETLANGUAGE")
            {
                ret = new SetLanguageActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "PLAYMSG")
            {
                ret = new PlayMsgActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "GETDIGITS")
            {
                ret = new GetDigitsActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "BRIDGECALL")
            {
                ret = new BridgeCallActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "RECORD")
            {
                ret = new RecordActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "AGI")
            {
                ret = new AGIActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "AUTHENTICATE")
            {
                ret = new AuthenticateActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "GOTO")
            {
                ret = new GotoActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "SUBPROC")
            {
                ret = new SubProcActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "SUBPROCEND")
            {
                ret = new SubProcEndActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "READ")
            {
                ret = new ReadActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "SET")
            {
                ret = new SetActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "COMPARE")
            {
                ret = new CompareActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "CALCULATION")
            {
                ret = new CalculationActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "SAY")
            {
                ret = new SayActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "CUT")
            {
                ret = new CutActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "LENGTH")
            {
                ret = new LengthActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "MERGE")
            {
                ret = new MergeActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "CHANGEEXT")
            {
                ret = new ChangeExtActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "GOTOIFTIME")
            {
                ret = new GotoIfTimeActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "MIXMONITOR")
            {
                ret = new MixMonitorActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "STOPMIXMONITOR")
            {
                ret = new StopMixMonitorActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "VOICEMAIL")
            {
                ret = new VoiceMailActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "VOICEMAILMAIN")
            {
                ret = new VoiceMailMainActivity() as IActivity;
            }
            else if (strActivity.ToUpper() == "SWITCHCASE")
            {
                ret = new SwitchCaseActivity() as IActivity;
            }

            return ret;
        }
    }
}
