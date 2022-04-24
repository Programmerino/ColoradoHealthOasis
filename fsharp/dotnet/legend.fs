module Legend

let legend = """
<g>
    <g transform="translate(0, 7)">
        <defs>
            <pattern id="fill-canvas-color-g-1" patternUnits="userSpaceOnUse" width="12" height="12"><svg width="12"
                    height="12">
                    <rect width="6" height="6" fill="rgba(14, 33, 39, 0.25)"></rect>
                    <rect width="6" height="6" x="6" y="6" fill="rgba(14, 33, 39, 0.25)"></rect>
                </svg></pattern>
            <linearGradient id="color-g-1" gradientUnits="userSpaceOnUse" x1="0%" y1="0%" x2="186" y2="0%">
                <stop offset="0%" stop-color="rgba(0,0,0,0)"></stop>
                <stop offset="2.272727272727273%" stop-color="rgba(65,105,225,0.22727272727272727)"></stop>
                <stop offset="4.545454545454546%" stop-color="rgba(65,105,225,0.45454545454545453)"></stop>
                <stop offset="6.8181818181818175%" stop-color="rgba(65,105,225,0.6818181818181818)"></stop>
                <stop offset="9.090909090909092%" stop-color="rgba(65,105,225,0.9090909090909091)"></stop>
                <stop offset="10%" stop-color="rgba(65,105,225,1)"></stop>
                <stop offset="12.272727272727273%" stop-color="rgba(58,122,228,1)"></stop>
                <stop offset="14.545454545454547%" stop-color="rgba(50,139,232,1)"></stop>
                <stop offset="16.818181818181817%" stop-color="rgba(43,156,235,1)"></stop>
                <stop offset="19.090909090909093%" stop-color="rgba(35,173,239,1)"></stop>
                <stop offset="21.363636363636367%" stop-color="rgba(28,190,242,1)"></stop>
                <stop offset="23.636363636363637%" stop-color="rgba(21,207,245,1)"></stop>
                <stop offset="25.90909090909091%" stop-color="rgba(13,224,249,1)"></stop>
                <stop offset="28.18181818181818%" stop-color="rgba(6,241,252,1)"></stop>
                <stop offset="30%" stop-color="rgba(0,255,255,1)"></stop>
                <stop offset="32.272727272727266%" stop-color="rgba(0,255,226,1)"></stop>
                <stop offset="34.54545454545455%" stop-color="rgba(0,255,197,1)"></stop>
                <stop offset="36.81818181818181%" stop-color="rgba(0,255,168,1)"></stop>
                <stop offset="39.090909090909086%" stop-color="rgba(0,255,139,1)"></stop>
                <stop offset="41.36363636363637%" stop-color="rgba(0,255,110,1)"></stop>
                <stop offset="43.63636363636363%" stop-color="rgba(0,255,81,1)"></stop>
                <stop offset="45.90909090909091%" stop-color="rgba(0,255,52,1)"></stop>
                <stop offset="48.18181818181818%" stop-color="rgba(0,255,23,1)"></stop>
                <stop offset="50%" stop-color="rgba(0,255,0,1)"></stop>
                <stop offset="52.27272727272727%" stop-color="rgba(29,255,0,1)"></stop>
                <stop offset="54.54545454545454%" stop-color="rgba(58,255,0,1)"></stop>
                <stop offset="56.81818181818182%" stop-color="rgba(87,255,0,1)"></stop>
                <stop offset="59.09090909090909%" stop-color="rgba(116,255,0,1)"></stop>
                <stop offset="61.36363636363637%" stop-color="rgba(145,255,0,1)"></stop>
                <stop offset="63.63636363636363%" stop-color="rgba(174,255,0,1)"></stop>
                <stop offset="65.9090909090909%" stop-color="rgba(203,255,0,1)"></stop>
                <stop offset="68.18181818181817%" stop-color="rgba(232,255,0,1)"></stop>
                <stop offset="70%" stop-color="rgba(255,255,0,1)"></stop>
                <stop offset="72.27272727272727%" stop-color="rgba(255,236,0,1)"></stop>
                <stop offset="74.54545454545453%" stop-color="rgba(255,216,0,1)"></stop>
                <stop offset="76.81818181818181%" stop-color="rgba(255,197,0,1)"></stop>
                <stop offset="79.0909090909091%" stop-color="rgba(255,178,0,1)"></stop>
                <stop offset="81.36363636363636%" stop-color="rgba(255,158,0,1)"></stop>
                <stop offset="83.63636363636363%" stop-color="rgba(255,139,0,1)"></stop>
                <stop offset="85.9090909090909%" stop-color="rgba(255,120,0,1)"></stop>
                <stop offset="88.18181818181817%" stop-color="rgba(255,100,0,1)"></stop>
                <stop offset="90.45454545454544%" stop-color="rgba(255,81,0,1)"></stop>
                <stop offset="92.72727272727272%" stop-color="rgba(255,62,0,1)"></stop>
                <stop offset="95%" stop-color="rgba(255,43,0,1)"></stop>
                <stop offset="97.27272727272727%" stop-color="rgba(255,23,0,1)"></stop>
                <stop offset="99.54545454545453%" stop-color="rgba(255,4,0,1)"></stop>
                <stop offset="101.81818181818181%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="104.09090909090908%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="106.36363636363635%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="108.63636363636363%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="110.9090909090909%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="113.18181818181819%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="115.45454545454545%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="117.72727272727272%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="120%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="122.27272727272727%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="124.54545454545453%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="126.81818181818181%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="129.09090909090907%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="131.36363636363635%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="133.63636363636363%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="135.9090909090909%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="138.1818181818182%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="140.45454545454547%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="142.72727272727272%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="145%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="147.27272727272725%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="149.54545454545453%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="151.8181818181818%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="154.09090909090907%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="156.36363636363635%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="158.63636363636363%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="160.9090909090909%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="163.1818181818182%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="165.45454545454547%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="167.72727272727272%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="170%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="172.27272727272725%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="174.54545454545453%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="176.8181818181818%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="179.09090909090907%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="181.36363636363635%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="183.63636363636363%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="185.9090909090909%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="188.1818181818182%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="190.45454545454547%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="192.72727272727272%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="195%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="197.27272727272725%" stop-color="rgba(255,0,0,1)"></stop>
                <stop offset="199.54545454545453%" stop-color="rgba(255,0,0,1)"></stop>
            </linearGradient>
        </defs>
        <rect fill="url('#fill-canvas-color-g-1')" width="198" x="-6" rx="6" ry="6" height="12" class="round"
            stroke="rgba(14, 33, 39, 0.50)" stroke-width="1"></rect>
        <rect fill="url('#color-g-1')" width="198" x="-6" rx="6" ry="6" height="12" class="round"
            stroke="rgba(14, 33, 39, 0.50)" stroke-width="1"></rect>
    </g>
</g>
"""