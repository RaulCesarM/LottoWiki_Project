import { Component, AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import * as Tone from 'tone';

@Component({
  selector: 'app-lorenz-attractor',
  templateUrl: './lorenz-attractor.component.html',
  styleUrls: ['./lorenz-attractor.component.css']
})
export class LorenzAttractorComponent implements AfterViewInit {
  @ViewChild('lorenzCanvas', { static: true }) canvasRef!: ElementRef<HTMLCanvasElement>;

  private oscillator: Tone.Oscillator;
  private gain: Tone.Gain;
  private reverb: Tone.Reverb;
  private filter: Tone.Filter;
  public isAudioStarted = false;

  constructor() {
    this.oscillator = new Tone.Oscillator({
      type: 'sine',
      frequency: 220
    });

    this.gain = new Tone.Gain(0.2);
    this.reverb = new Tone.Reverb({ decay: 3, wet: 0.4 });
    this.filter = new Tone.Filter({ type: 'lowpass', frequency: 1200, Q: 1 });

    this.oscillator.chain(this.gain, this.filter, this.reverb, Tone.Destination);
  }

  ngAfterViewInit(): void {
    this.animateLorenzAttractor();
  }

  toggleAudio(): void {
    if (this.isAudioStarted) {
      this.stopAudio();
    } else {
      this.startAudio();
    }
  }

  private async startAudio():Promise< void> {
    await Tone.start(); 
    this.isAudioStarted = true;
    this.oscillator.start();
  }

  private stopAudio(): void {
    this.oscillator.stop();
    this.isAudioStarted = false;
  }

  animateLorenzAttractor(): void {
    const canvas = this.canvasRef.nativeElement;
    const ctx = canvas.getContext('2d');

    if (!ctx) {
      console.error('Erro: Não foi possível obter o contexto do canvas!');
      return;
    }

    canvas.width = 950;
    canvas.height = 700;
    ctx.clearRect(0, 0, canvas.width, canvas.height);

    let x = 0.01, y = 0, z = 0;
    let dt = 0.01;
    let sigma = 10, rho = 28, beta = 8 / 3;
    let scale = 11;
    let centerX = canvas.width / 2;
    let centerY = canvas.height - 100;

    ctx.beginPath();

    const updateSound = () => {
      const newFrequency = Math.max(100, Math.min(1000, Math.abs(x) * 30 + 220));
      this.oscillator.frequency.linearRampToValueAtTime(newFrequency, Tone.now() + 0.1);

      const newVolume = Math.min(1, Math.abs(z) / 50);
      this.gain.gain.linearRampToValueAtTime(newVolume, Tone.now() + 0.1);

      const filterFreq = Math.max(500, Math.min(2000, newFrequency));
      this.filter.frequency.linearRampToValueAtTime(filterFreq, Tone.now() + 0.2);
    };

    const draw = () => {
      let dx = sigma * (y - x) * dt;
      let dy = (x * (rho - z) - y) * dt;
      let dz = (x * y - beta * z) * dt;

      x += dx;
      y += dy;
      z += dz;

      let px = centerX + x * scale;
      let py = centerY - z * scale;

      ctx.lineTo(px, py);
      ctx.strokeStyle = 'blue';
      ctx.lineWidth = 1.5;
      ctx.stroke();

      if (this.isAudioStarted) {
        updateSound();
      }

      requestAnimationFrame(draw);
    };

    draw();
  }
}
