Shader "GLSL basic shader" { // defines the name of the shader 
   SubShader { // Unity chooses the subshader that fits the GPU best
      Pass { // some shaders require multiple passes
         GLSLPROGRAM // here begins the part in Unity's GLSL

         #ifdef VERTEX // here begins the vertex shader

         void main() // all vertex shaders define a main() function
         {
            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

         }

         #endif // here ends the definition of the vertex shader


         #ifdef FRAGMENT // here begins the fragment shader
         sampler2D _MainTex;
         void main() // all fragment shaders define a main() function
         {
            gl_FragColor = tex2D(_MainTex,i.uv); 
         }

         #endif // here ends the definition of the fragment shader

         ENDGLSL // here ends the part in GLSL 
      }
   }
}