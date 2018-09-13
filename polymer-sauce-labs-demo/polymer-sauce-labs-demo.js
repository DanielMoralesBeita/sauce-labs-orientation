import {html, PolymerElement} from '@polymer/polymer/polymer-element.js';

/**
 * `polymer-sauce-labs-demo`
 * Polymer Sauce Labs Demonstration
 *
 * @customElement
 * @polymer
 * @demo demo/index.html
 */
class PolymerSauceLabsDemo extends PolymerElement {
  static get template() {
    return html`
      <style>
        :host {
          display: block;
        }
      </style>
      <h2>Hello [[prop1]]!</h2>
    `;
  }
  static get properties() {
    return {
      prop1: {
        type: String,
        value: 'polymer-sauce-labs-demo',
      },
    };
  }
}

window.customElements.define('polymer-sauce-labs-demo', PolymerSauceLabsDemo);
