// This is built off of a UnityDiscussion user's code and was then added onto to apply the moving scan lines effect

Shader "Custom/Scanlines" { 
    Properties { 
        _Color("Color", Color) = (0,0,0,1) 
        _LinesSize("LinesSize", Range(1,10)) = 1 
        _EffectSpeed ("Effect Speed", Float) = 1.0
    } 
    SubShader { 
        Tags {
        "RenderType" = "Opaque"
        "Queue" = "Transparent"
        } 

        Fog { Mode Off } 

        Pass { 
            Cull Off
            ZTest Always 
            ZWrite Off 
            Blend SrcAlpha OneMinusSrcAlpha
    
    CGPROGRAM
    
    #pragma vertex vert 
    #pragma fragment frag
    #include "UnityCG.cginc"
    
            fixed4 _Color;
            float _EffectSpeed;
            half _LinesSize;
            
            
            struct v2f { 
                half4 pos:POSITION; 
                fixed4 sPos:TEXCOORD; 
            };
    
            v2f vert(appdata_base v) {
                

                v2f o; o.pos = UnityObjectToClipPos(v.vertex); 
                o.sPos = ComputeScreenPos(o.pos); 
                return o; 
            }
    
            fixed4 frag(v2f i) : COLOR {
                float t = _Time.x * _EffectSpeed;
                float2 offset = sin(t) * 0.5;

                fixed p = (i.sPos.y + offset) / i.sPos.w;
                if (sin(t) == 1) {
                    _LinesSize += 1;
                }
                else if (sin(t) == -1) {
                    _LinesSize -= 1;
                }

    
                if((int)(p*_ScreenParams.y/floor(_LinesSize))%2==0) discard;
                   return _Color; 
             }
    
    ENDCG
           }
    
    } 
    }