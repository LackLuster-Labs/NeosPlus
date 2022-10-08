﻿using System;
using BaseX;
using FrooxEngine;
using NEOSPlus.Shaders;
using static FrooxEngine.MeshUploadHint;

namespace NEOSPlus.Materials
{
    [Category(new string[] { "Assets/Materials/NeosPlus" })]
    public class MToon : SingleShaderMaterialProvider
    {
        protected override Uri ShaderURL => ShaderInjection.MToon;

        public readonly Sync<float> Cutoff;
        [Range(0f, 1f)] private static MaterialProperty _Cutoff = new MaterialProperty("_Cutoff");
        public readonly Sync<color> Color;
        private static MaterialProperty _Color= new MaterialProperty("_Color");
        public readonly Sync<color> ShadeColor;
        private static MaterialProperty _ShadeColor= new MaterialProperty("_ShadeColor");
        public readonly AssetRef<ITexture2D> MainTex;
        private static MaterialProperty _MainTex = new MaterialProperty("_MainTex");
        public readonly AssetRef<ITexture2D> ShadeTexture;
        private static MaterialProperty _ShadeTexture = new MaterialProperty("_ShadeTexture");
        public readonly Sync<float> BumpScale;
        private static MaterialProperty _BumpScale= new MaterialProperty("_BumpScale");
        public readonly AssetRef<ITexture2D> BumpMap;
        private static MaterialProperty _BumpMap = new MaterialProperty("_BumpMap");
        public readonly Sync<float> ReceiveShadowRate;
        [Range(0f, 1f)] private static MaterialProperty _ReceiveShadowRate = new MaterialProperty("_ReceiveShadowRate");
        public readonly AssetRef<ITexture2D> ReceiveShadowTexture;
        private static MaterialProperty _ReceiveShadowTexture = new MaterialProperty("_ReceiveShadowTexture");
        public readonly Sync<float> ShadingGradeRate;
        [Range(0f, 1f)] private static MaterialProperty _ShadingGradeRate = new MaterialProperty("_ShadingGradeRate");
        public readonly AssetRef<ITexture2D> ShadingGradeTexture;
        private static MaterialProperty _ShadingGradeTexture = new MaterialProperty("_ShadingGradeTexture");
        public readonly Sync<float> ShadeShift;
        [Range(-1f, 1f)] private static MaterialProperty _ShadeShift = new MaterialProperty("_ShadeShift");
        public readonly Sync<float> ShadeToony;
        [Range(0f, 1f)] private static MaterialProperty _ShadeToony = new MaterialProperty("_ShadeToony");
        public readonly Sync<float> LightColorAttenuation;
        [Range(0f, 1f)] private static MaterialProperty _LightColorAttenuation = new MaterialProperty("_LightColorAttenuation");
        public readonly Sync<float> IndirectLightIntensity;
        [Range(0f, 1f)] private static MaterialProperty _IndirectLightIntensity = new MaterialProperty("_IndirectLightIntensity");
        public readonly Sync<color> RimColor;
        private static MaterialProperty _RimColor= new MaterialProperty("_RimColor");
        public readonly AssetRef<ITexture2D> RimTexture;
        private static MaterialProperty _RimTexture = new MaterialProperty("_RimTexture");
        public readonly Sync<float> RimLightingMix;
        [Range(0f, 1f)] private static MaterialProperty _RimLightingMix = new MaterialProperty("_RimLightingMix");
        public readonly Sync<float> RimFresnelPower;
        [Range(0f, 100f)] private static MaterialProperty _RimFresnelPower = new MaterialProperty("_RimFresnelPower");
        public readonly Sync<float> RimLift;
        [Range(0f, 1f)] private static MaterialProperty _RimLift = new MaterialProperty("_RimLift");
        public readonly AssetRef<ITexture2D> SphereAdd;
        private static MaterialProperty _SphereAdd = new MaterialProperty("_SphereAdd");
        public readonly Sync<color> EmissionColor;
        private static MaterialProperty _EmissionColor = new MaterialProperty("_EmissionColor");
        public readonly AssetRef<ITexture2D> EmissionMap;
        private static MaterialProperty _EmissionMap = new MaterialProperty("_EmissionMap");
        public readonly AssetRef<ITexture2D> OutlineWidthTexture;
        private static MaterialProperty _OutlineWidthTexture = new MaterialProperty("_OutlineWidthTexture");
        public readonly Sync<float> OutlineWidth;
        [Range(0.01f, 1f)] private static MaterialProperty _OutlineWidth = new MaterialProperty("_OutlineWidth");
        public readonly Sync<float> OutlineScaledMaxDistance;
        [Range(0f, 10f)] private static MaterialProperty _OutlineScaledMaxDistance = new MaterialProperty("_OutlineScaledMaxDistance");
        public readonly Sync<color> OutlineColor;
        private static MaterialProperty _OutlineColor= new MaterialProperty("_OutlineColor");
        public readonly Sync<float> OutlineLightingMix;
        [Range(0f, 1f)] private static MaterialProperty _OutlineLightingMix = new MaterialProperty("_OutlineLightingMix");
        public readonly AssetRef<ITexture2D> UvAnimMaskTexture;
        private static MaterialProperty _UvAnimMaskTexture = new MaterialProperty("_UvAnimMaskTexture");
        public readonly Sync<float> UvAnimScrollX;
        private static MaterialProperty _UvAnimScrollX= new MaterialProperty("_UvAnimScrollX");
        public readonly Sync<float> UvAnimScrollY;
        private static MaterialProperty _UvAnimScrollY= new MaterialProperty("_UvAnimScrollY");
        public readonly Sync<float> UvAnimRotation;
        private static MaterialProperty _UvAnimRotation = new MaterialProperty("_UvAnimRotation");

        public readonly Sync<float> MToonVersion;
        public readonly Sync<float> DebugMode;
        public readonly Sync<float> BlendMode;
        public readonly Sync<float> OutlineWidthMode;
        public readonly Sync<float> OutlineColorMode;
        public readonly Sync<float> CullMode;
        public readonly Sync<float> OutlineCullMode;
        public readonly Sync<float> SrcBlend;
        public readonly Sync<float> DstBlend;
        public readonly Sync<float> ZWrite;
        public readonly Sync<float> AlphaToMask;
        private static MaterialProperty _MToonVersion = new MaterialProperty("_MToonVersion");
        private static MaterialProperty _DebugMode = new MaterialProperty("_DebugMode");
        private static MaterialProperty _BlendMode = new MaterialProperty("_BlendMode");
        private static MaterialProperty _OutlineWidthMode = new MaterialProperty("_OutlineWidthMode");
        private static MaterialProperty _OutlineColorMode = new MaterialProperty("_OutlineColorMode");
        private static MaterialProperty _CullMode = new MaterialProperty("_CullMode");
        private static MaterialProperty _OutlineCullMode = new MaterialProperty("_OutlineCullMode");
        private static MaterialProperty _SrcBlend = new MaterialProperty("_SrcBlend");
        private static MaterialProperty _DstBlend = new MaterialProperty("_DstBlend");
        private static MaterialProperty _ZWrite = new MaterialProperty("_ZWrite");
        private static MaterialProperty _AlphaToMask  = new MaterialProperty("_AlphaToMask");

        [DefaultValue(-1)]
        public readonly Sync<int> RenderQueue;
        private static PropertyState _propertyInitializationState;

        public override PropertyState PropertyInitializationState
        {
            get => _propertyInitializationState;
            protected set => _propertyInitializationState = value;
        }
        protected override void UpdateMaterial(Material material)
        {
            material.UpdateTexture(_MainTex, MainTex);
            material.UpdateTexture(_ShadeTexture, ShadeTexture);
            material.UpdateTexture(_RimTexture, RimTexture);
            material.UpdateTexture(_BumpMap, BumpMap);
            material.UpdateTexture(_ReceiveShadowTexture, ReceiveShadowTexture);
            material.UpdateTexture(_ShadingGradeTexture, ShadingGradeTexture);
            material.UpdateTexture(_SphereAdd, SphereAdd);
            material.UpdateTexture(_EmissionMap, EmissionMap);
            material.UpdateTexture(_OutlineWidthTexture, OutlineWidthTexture);
            material.UpdateTexture(_UvAnimMaskTexture, UvAnimMaskTexture);

            material.UpdateColor(_Color, Color);
            material.UpdateColor(_ShadeColor, ShadeColor);
            material.UpdateColor(_RimColor, RimColor);
            material.UpdateColor(_OutlineColor, OutlineColor);
            material.UpdateColor(_EmissionColor, EmissionColor);

            material.UpdateFloat(_Cutoff, Cutoff);
            material.UpdateFloat(_ReceiveShadowRate, ReceiveShadowRate);
            material.UpdateFloat(_ShadingGradeRate, ShadingGradeRate);
            material.UpdateFloat(_ShadeShift, ShadeShift);
            material.UpdateFloat(_ShadeToony, ShadeToony);
            material.UpdateFloat(_LightColorAttenuation, LightColorAttenuation);
            material.UpdateFloat(_IndirectLightIntensity, IndirectLightIntensity);
            material.UpdateFloat(_RimLightingMix, RimLightingMix);
            material.UpdateFloat(_RimLift, RimLift);
            material.UpdateFloat(_RimFresnelPower, RimFresnelPower);
            material.UpdateFloat(_OutlineWidth, OutlineWidth);
            material.UpdateFloat(_OutlineScaledMaxDistance, OutlineScaledMaxDistance);
            material.UpdateFloat(_OutlineLightingMix, OutlineLightingMix);

            material.UpdateFloat(_BumpScale, BumpScale);
            material.UpdateFloat(_UvAnimScrollX, UvAnimScrollX);
            material.UpdateFloat(_UvAnimScrollY, UvAnimScrollY);
            material.UpdateFloat(_UvAnimRotation, UvAnimRotation);

            material.UpdateFloat(_MToonVersion, MToonVersion);
            material.UpdateFloat(_DebugMode, DebugMode);
            material.UpdateFloat(_BlendMode, BlendMode);
            material.UpdateFloat(_OutlineWidthMode, OutlineWidthMode);
            material.UpdateFloat(_OutlineColorMode, OutlineColorMode);
            material.UpdateFloat(_CullMode, CullMode);
            material.UpdateFloat(_OutlineCullMode, OutlineCullMode);
            material.UpdateFloat(_SrcBlend, SrcBlend);
            material.UpdateFloat(_DstBlend, DstBlend);
            material.UpdateFloat(_ZWrite, ZWrite);
            material.UpdateFloat(_AlphaToMask, AlphaToMask);

            if (!RenderQueue.GetWasChangedAndClear()) return;
            var renderQueue = RenderQueue.Value;
            if ((int)RenderQueue == -1) renderQueue = 2600;
            material.SetRenderQueue(renderQueue);
        }

        protected override void UpdateKeywords(ShaderKeywords keywords) { }
        protected override void OnAttach()
        {
            base.OnAttach();
            Cutoff.Value = 0.5f;
            ReceiveShadowRate.Value = 1f;
            ShadingGradeRate.Value = 1f;
            LightColorAttenuation.Value = 0;
            IndirectLightIntensity.Value = 0.1f;
            RimLightingMix.Value = 0f;
            RimFresnelPower.Value = 1f;
            RimLift.Value = 1f;
            ShadeShift.Value = 0f;
            ShadeToony.Value = 0.9f;
            OutlineWidth.Value = 0.5f;
            OutlineLightingMix.Value = 1f;
            OutlineScaledMaxDistance.Value = 1f;
            Color.Value = new color(1);
            ShadeColor.Value = new color(0.97f, 0.81f, 0.86f, 1);
            RimColor.Value = new color(0,0,0,0);
            EmissionColor.Value = new color(0,0,0,1);
            OutlineColor.Value = new color(0,0,0,1);
            BumpScale.Value = 1;
            UvAnimScrollX.Value = 0;
            UvAnimScrollY.Value = 0;
            UvAnimRotation.Value = 0;

            MToonVersion.Value = 38;
            DebugMode.Value = 0;
            BlendMode.Value = 0;
            OutlineWidthMode.Value = 0;
            OutlineColorMode.Value = 0;
            CullMode.Value = 2;
            OutlineCullMode.Value = 1;
            SrcBlend.Value = 1;
            DstBlend.Value = 0;
            ZWrite.Value = 1;
            AlphaToMask.Value = 0;
        }
    }
}