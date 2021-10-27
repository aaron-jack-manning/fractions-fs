namespace Fractions

module Operations =
    let private reduceMod modulus number =
        (number % modulus + modulus) % modulus
    
    let private division a b =
        let remainder = reduceMod b a
        let quotient = (a - remainder)/ b
        
        quotient, remainder
    
    let rec private greatestCommonDenominator a b =
        let quotient, remainder = division a b
    
        match remainder with
        | 0 -> b
        | _ -> greatestCommonDenominator b remainder
    
    let private lowestCommonMultiple a b =
        (a * b) / (greatestCommonDenominator a b)

    [<StructuredFormatDisplay("{Numerator}/{Denominator}")>]
    type Fraction(numerator, denominator) =
    
        member this.Numerator = numerator
        member this.Denominator = denominator
    
        static member simplify (a : Fraction) : Fraction =
            let gcd = greatestCommonDenominator a.Numerator a.Denominator
            
            let newNumerator = a.Numerator / gcd
            let newDenominator = a.Denominator / gcd
            
            if newDenominator < 0 then
                Fraction(-newNumerator, -newDenominator)
            else
                Fraction(newNumerator, newDenominator)
    
        static member (/) (a : Fraction, b : Fraction) : Fraction =
            Fraction.simplify (Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator))
    
        static member (*) (a : Fraction, b : Fraction) : Fraction =
            Fraction.simplify (Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator))
    
        static member (+) (a : Fraction, b : Fraction) : Fraction =
            Fraction.simplify (Fraction(a.Numerator * b.Denominator + a.Denominator * b.Numerator, a.Denominator * b.Denominator))
    
        static member (-) (a : Fraction, b : Fraction) : Fraction =
            Fraction.simplify (Fraction(a.Numerator * b.Denominator - a.Denominator * b.Numerator, a.Denominator * b.Denominator))
        
        static member ( ^^ ) (a : Fraction, power : int) : Fraction =
            if power < 0 then
                let positivePower = -power
                Fraction(pown a.Denominator positivePower, pown a.Numerator positivePower)
            else
                Fraction(pown a.Numerator power, pown a.Denominator power)
        
        member this.asFloat =
            (float this.Numerator) / (float this.Denominator)
    
        member this.asDecimal =
            (decimal this.Numerator) / (decimal this.Denominator)
              
        member this.isWhole =
            this.Denominator = 1
