﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BubbleTweaks.Utilities {
    public static class UIHelpers {
        public static T Edit<T>(this Transform obj, Action<T> build) where T : Component {
            var component = obj.GetComponent<T>();
            build(component);
            return component;
        }
        public static T Edit<T>(this GameObject obj, Action<T> build) where T : Component {
            var component = obj.GetComponent<T>();
            build(component);
            return component;
        }

        public static T MakeComponent<T>(this GameObject obj, Action<T> build) where T : Component {
            var component = obj.AddComponent<T>();
            build(component);
            return component;
        }
        public static void AddTo(this Transform obj, Transform parent) {
            obj.SetParent(parent);
            obj.localPosition = Vector3.zero;
            obj.localScale = Vector3.one;
            obj.localRotation = Quaternion.identity;
        }

        public static void AddTo(this Transform obj, GameObject parent) { obj.AddTo(parent.transform); }
        public static void AddTo(this GameObject obj, Transform parent) { obj.transform.AddTo(parent); }
        public static void AddTo(this GameObject obj, GameObject parent) { obj.transform.AddTo(parent.transform); }

        public static RectTransform Rect(this GameObject obj) {
            return obj.transform as RectTransform;
        }

        private static string MakeTitleCharacter(this char ch) {
            string voffset = "0.1";
            if (ch == 'F' || ch == 'f')
                voffset = "0.2";

            return $"<voffset={voffset}em><font=\"Saber_Dist32\"><color=#672B31><size=130%>{ch}</size></color></font></voffset>";
        }

        public static string MakeTitle(this string str) {
            if (str.Length == 0)
                return "";

            var ret = str[0].MakeTitleCharacter();
            if (str.Length > 1)
                ret += str.Substring(1);
            return ret;
        }
    }
}
