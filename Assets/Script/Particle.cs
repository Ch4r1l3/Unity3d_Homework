using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePosition
{
    public float radius = 0f, angle = 0f, time = 0f;
    public CirclePosition(float radius, float angle, float time)
    {
        this.radius = radius;     
        this.angle = angle;      
        this.time = time;  
    }
}

public class Particle : MonoBehaviour {
    public ParticleSystem particle;
    private ParticleSystem.Particle[] particlesArray;
    private CirclePosition[] circle;

    public int count = 1000;       // 粒子数量  
    public float size = 0.3f;      // 粒子大小  
    public bool clockwise = true;   // 顺时针|逆时针  
    public float speed = 2f;        // 速度  
    public float pingPong = 0.02f;  // 游离范围  

    void RandomlySpread()
    {
        for (int i = 0; i < count; ++i)
        {   // 随机每个粒子距离中心的半径，同时希望粒子集中在平均半径附近  
            float radius = Random.Range(0.9f, 1.1f);

            // 随机每个粒子的角度  
            float angle = Random.Range(0.0f, 360.0f);
            float theta = angle / 180 * Mathf.PI;

            // 随机每个粒子的游离起始时间  
            float time = Random.Range(0.0f, 360.0f);
            
            float x = radius* 13 * (Mathf.Sin(theta) * Mathf.Sin(theta) * Mathf.Sin(theta));
            float y = radius* 10 * Mathf.Cos(theta) - 5 * Mathf.Cos(2 * theta) - 2 * Mathf.Cos(3 * theta) - Mathf.Cos(4 * theta);

            circle[i] = new CirclePosition(radius, angle, time);

            particlesArray[i].position = new Vector3(x, 0f, y);
        }

        particle.SetParticles(particlesArray, particlesArray.Length);
    }

    void Start () {
        particlesArray = new ParticleSystem.Particle[count];
        circle = new CirclePosition[count];

        // 初始化粒子系统  
        particle = this.GetComponent<ParticleSystem>();
        particle.startSize = size;          // 设置粒子大小  
        particle.Emit(count);               // 发射粒子  
        particle.GetParticles(particlesArray);
        RandomlySpread();   // 初始化各粒子位置  
    }
	
	// Update is called once per frame
	void Update () {
        for(int i=0;i<count;i++)
        {
            if (clockwise)
                circle[i].angle -= 0.1f;
            else
                circle[i].angle += 0.1f;

            circle[i].angle = (360.0f + circle[i].angle) % 360.0f;
            float theta = circle[i].angle / 180 * Mathf.PI;
            float x = circle[i].radius * 13 * (Mathf.Sin(theta) * Mathf.Sin(theta) * Mathf.Sin(theta));
            float y = circle[i].radius * 10 * Mathf.Cos(theta) - 5 * Mathf.Cos(2 * theta) - 2 * Mathf.Cos(3 * theta) - Mathf.Cos(4 * theta);
            particlesArray[i].position = new Vector3(x, 0f, y);
        }
        particle.SetParticles(particlesArray, particlesArray.Length);
    }
}
