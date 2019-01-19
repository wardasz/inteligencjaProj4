using System;
using System.Collections.Generic;
using System.Linq;

namespace step2
{
    class Program
    {
        static List<slowo> slowa = new List<slowo>();
        static List<dziedzina> dziedziny = new List<dziedzina>();       

        static void Main(string[] args)
        {
            utwozDziedziny();
            //wersja pc
            string text = System.IO.File.ReadAllText(@"D:\studia\magisterka\sem1\inteligencja\proj4\inteligencjaProj4\oczyszczony.txt");
            //wersja laptop
            //string text = System.IO.File.ReadAllText(@"D:\studia\sem1\inteligencja\proj4\inteligencjaProj4\oczyszczony.txt");
            string[] words = text.Split(' ');

            foreach(string s in words)
            {
                if (s.Length > 2) {
                    slowo sl = slowa.Select(n => n).Where(x => x.dajSlowo() == s).FirstOrDefault();
                    if (sl == null)
                    {
                        slowa.Add(new slowo(s));
                    }
                    else
                    {
                        sl.podbij();
                    }
                }
            }

            foreach(slowo s in slowa)
            {
                Console.WriteLine(s.dajSlowo() + " " + s.dajIle());
            }
            Console.WriteLine();
            foreach (dziedzina d in dziedziny)
            {
                d.porownaj(slowa);
            }

            dziedzina winer = new dziedzina("nicosc", new string[] { "pustka"});
            foreach(dziedzina d in dziedziny)
            {
                Console.WriteLine("Artykół zawiera " + d.dajZbieznosc() + " słów z dziedziny " + d.dajNazwe());
                if (d.dajZbieznosc() > winer.dajZbieznosc()) { winer = d; }
            }
            Console.WriteLine();
            Console.WriteLine("Najprawdopodobniej artykuł należy do kategorii " + winer.dajNazwe());


            Console.ReadKey();
        }


        public static void utwozDziedziny()
        {
            string[] tmp;
            dziedzina TMP;
            tmp = new string[]{ "chemical", "chemistry", "substance", "substances", "toxic", "reaction", "react", "atom", "molecule", "ion", "atoms", "molecules", "ions",
                "equation", "formula", "formulas", "acid", "acids", "base", "bases", "metal", "metals", "nonmetals", "nonmetal", "element", "elements", "group", "groups",
                "period", "periods", "periodic", "table", "salt", "salts", "hydroxide", "hydrogen", "helium", "lithium", "beryllium", "boron", "carbon", "nitrogen",
                "oxygen", "fluorine", "neon", "sodium", "magnesium", "aluminium", "silicon", "phosphorus", "suplfur", "chlorine", "argon", "potassium", "calcium",
                "scandium", "totanium", "vanadium", "chromium", "manganese", "iron", "cobalt", "nickel", "copper", "zinc", "gallium", "germanium", "arsenic", "selenium",
                "bromine", "krypton", "rubidium", "strontium", "yttrium", "zirkonium", "niobium", "molybdenum", "technetium", "ruthenium", "rhodium", "palladium", "silver",
                "cadmium", "indium", "tin", "antimony", "tellurium", "iodyne", "xenon", "caesium", "barium", "lanthanum", "hafnium", "tantalum", "tungsten", "rhenium",
                "osmium", "iridium", "platinum", "gold", "mercury", "thallium", "lead", "bismuth", "polonium", "astatine", "radon", "francium", "radium", "actinium",
                "rutherfordium", "dubnium", "seaborgium", "bohrium", "hassium", "maitnerium", "darmstadium", "roentgenium", "copernicium", "nihonium", "flerovium",
                "moscovium", "livermorium", "tennessine", "oganession", "cerium", "praseodymium", "neodymium", "promethium", "samarium", "eropium", "gadolinium", "terbium",
                "dysprosium", "holmium", "erbium", "thulium", "ytterbium", "latetium", "thorium", "protactinium", "uranium", "neptunium", "plutonium", "americium", "curium",
                "berkelium", "californium", "einsteinium", "farmium", "mendelevium", "nobelium", "lawrencium", "ammonia", "compound", "liquid" , "fluid" , "fluids", "gas",
                "gases", "solid", "radiation", "exergonic", "endergonic", "peroxide", "peroxides", "superoxide", "superoxides", "oxide", "oxides", "oxidizing", "agent",
                "oxidant", "oxidizer", "reducing", "reductant", "reducer", "formic", "alcohol", "alcohols", "hydride", "hydrides", "amine", "amines", "enos", "enosl",
                "ester", "esters", "nitryle", "nitryles", "sulfone", "sulfones", "distillation", "separating", "mixture", "calcination", "lime", "dioxide", "devitrification",
                "filtration", "crystallization", "crystalic", "structure", "nucleation", "nuclear", "mole", "unit" };
            TMP = new dziedzina("chemia", tmp);
            dziedziny.Add(TMP);
            tmp = new string[] { "natural", "life", "death", "creation", "extinction", "extinct", "evolution", "organism", "organisms", "specie", "species", "system", "cell",
                "diversion", "multicellular", "monocellular", "colonial", "colony", "evolved", "genetics", "gene", "genes", "genetic", "dna", "rna", "mutation", "variation",
                "heredity", "patterns", "intracellular", "extracellular", "environment", "cells", "breeding", "breed", "homeostasis", "internal", "external", "temperature",
                "physiology", "physiologic", "medicine", " organisms", "organ", "system", "systems", "organs", "pathology", "pathological", "state", "anatomy", "anatomical",
                "cytopathology", "hematopathology", "histopathology", "dermatopathology", "neuropathology", "pulmonary", "renal", "surgical", "clinical", "immunopathology",
                "physiological", "genu", "genus", "family", "order", "orders", "families", "class", "clases", "phulym", "phylums", "kingdom", "kingdoms", "domain", "domains",
                "botany", "ecology", "microbiology", "zoology", "ethology", "entomology", "herpetology", "ichthyology", "mammalogy", "ornithology", "bird", "birds", "animal",
                "animals", "insect", "insects", "reptile", "reptiles", "reptilia", "amphibia", "amphibian", "amphibians", "fish", "fishs", "mammal", "mammals", "copulation",
                "copulate", "circulatory", "cardiovascular", "vascular", "arterie", "arteries", "vein", "veins", "heart", "lung", "lungs", "capillaries", "portal",
                "circulation", "brain", "disease", "diseases", "musculoskeletal", "locomotor", "skeleton", "muscles", "cartilage", "tendons", "ligaments", "joints",
                "connective", "tissue", "scull", "rib", "ribs", "ribcage", "nervous", "neurons", "glial", "nerve", "nerves", "neuron", "spine", "neck", "head", "limb", "limbs",
                "synapses", "synapse", "neural", "skin", "hair", "scales", "feathers", "hooves", "nails", "scale", "feather", "hoove", "nail", "epidermis", "dermis",
                "hypodermis", "tissues", "plant", "immune", "agent", "pathogens", "viruses", "parasitic", "worms", "pathogen", "virus", "worm", "phagocytosis",
                "antimicrobial", "peptides", "defensins", "lymphocyte", "lymphocytes", "respiratory", "ventilatory", "atria", "blood", "breath", "breathing", "digestive",
                "tongue", "salivary", "saliva", "gland", "glands", "pancrea", "pancreas", "liver", "gallbladder", "stomach", "teeth", "diaphragm", "spleen", "bile", "urinary",
                "kidneys", "ureters", "bladder", "urethra", "kidneys", "ureters", "prostate", "anus", "urine", "endocrine", "hormones", "adrenaline", "epinephrine",
                "neurotransmitter", "neurotransmitters", "sweat", "exocrine", "reproductive", "genital", "sex", "sexual", "reproduction", "gender", "sexes", "offspring",
                "male", "female", "scrotum", "penis", "testicle", "vagina", "vulva", "ovary", "placenta", };
            TMP = new dziedzina("biologia", tmp);
            dziedziny.Add(TMP);
            tmp = new string[] { "algorithm", "algorithms", "analysis", "binary", "decimal", "statistics", "data", "collection", "collection", "organization", "analysis",
                "interpretation", "presentation", "function", "variable", "class", "namespace", "cluster", "package", "library", "abstract", "optimization", "table", "tables",
                "integer", "string", "float", "double", "bool", "boolean", "int", "object", "oriented", "programing", "java", "ruby", "python", "computer", "computing",
                "scala", "swift", "perl", "php", "html", "css", "page", "web", "paradigms", "variable", "scalar", "run", "compile", "compilator", "assembly", "assembler",
                "instances", "prototype", "encapsulation", "composition", "inheritance", "delegation", "message", "polymorphism", "open", "close", "recursion", "recurency",
                "languages", "dynamic", "network", "protocol", "database", "sql", "relation", "relative", "responsibility", "single", "solid", "manipulate", "store",
                "communicate", "digital", "information", "complex", "system", "operational", "computer", "smart", "smartphone", "application", "software", "engineering",
                "programer", "machine", "image", "processing", "artificial", "neural", "intelligence", "learning", "conditional", "statements", "expressions", "runtime",
                "flag", "branch", "git", "repository", "expression", "statement", "conditionals", "loop", "loops", "infinite", "iteration", "iterator", "collection", "list",
                "array", "arraylist", "domain", "hub", "router", "switch", "lan", "wan", "man", "area", "local", "bug", "glitch", "artifact", "kayboard", "mause", "display",
                "monitor", "screen", "cpu", "proces", "procesing", "break", "security" };
            TMP = new dziedzina("informatyka", tmp);
            dziedziny.Add(TMP);
            tmp = new string[] {"liquid" , "fluid" , "fluids", "gas", "gases", "solid", "matter", "motion", "space", "time", "temperature", "thermodynamics", "dynamics",
                "heat", "energy", "work", "speed", "velocity", "entropy", "nuclear", "magnitude", "kinematics", "dimencion", "dimencions", "relativity", "light", "distance",
                "time", "average", "mechanics", "acceleration", "position", "vector", "relative", "trajectories", "trajectory", "constant", "rotation", "momentum", "static",
                "statics", "gravity", "gravitation", "natural", "phenomenon", "mass", "weight", "general", "theory", "proportional", "force", "object", "thrust", "drag",
                "torque", "deformation", "forces", " fundamental", "interactions", "interaction", "field", "wave", "disturbance", "transfers", "transfer", "radiation", "radio",
                "tension", "tensor", "point", "spinor", "electric", "magnetic", "electromagnetism", "electromagnetic", "interaction", " electrically", "charged", "particles",
                "particle", "weves", "fields", "atomic", "induction", "plasma", "magnetohydrodynamics", "acoustics", "acoustician", "vibration", "atom", "molecular", "orbital",
                "optic", "optics", "instrument", "instruments", "mirrors", "lenses", "telescopes", "microscopes", "lasers", "mirror", "lens", "telescope", "microscope",
                "laser", "fibre", "ampere", "candela", "kelvin", "kilogram", "metre", "mole", "second", "degree", "Celsius", "fahrenheit", "scale", "scales", "conversion",
                "bacquerel", "coulomb", "farad", "gray", "hertz", "katal", "lumen", "lux", "newton", "ohm", "pascal", "radian", "hectopascal", "siemens", "sievert", "volt",
                "watt", "steradian", "weber", "astronomical", "unit", "decibel", "minute", "hour", "litre", "arc", "tonne", "prefixe", "prifixes", "conservation", "transition",
                "equivalence", "power", "voltage", "potential", "dipole", "corcuit", "charge", "current" };
            TMP = new dziedzina("fizyka", tmp);
            dziedziny.Add(TMP);
            tmp = new string[] { "average", "scalar", "conversion", "prefixe", "prifixes", "mathematics", "math", "patterns", "pattern", "formulate", "formula", "conjectures",
                "conjecture", "truth", "falsity", "fasle", "true", "logic", "mathematical", "proof", "proofs", "abstraction", "game", "theory", "vector", "set", "computation",
                "algorithm", "algorithms", "algebra", "algebric", "algebraist", "number", "analysis", "arithmetic", "addition", "subtraction", "multiplication", "division",
                "combined", "decimal", "zero", "repeated", "geometry", "lengths", "areas", "volumes", "length", "area", "volume", "trigonometry", "angle", "angles", "degrees",
                "degree", "probability", "statistics", "data", "collection", "collection", "organization", "analysis", "interpretation", "presentation", "proportion", "model",
                "models", "cryptography", "cryptology", "straight", "line", "point", "linear", "equation", "curva", "curved", "curvature", "path", "graph", "topology",
                "topological", "parabola", "hiperbola", "polygonal", "chain", "polyline", "piecewise", "linear", "broken", "segment", "open", "close", "square", "triangle",
                "polygon", "vertice", "vertices", "shape", "shepes", "space", "regular", "rectangle", "quadrilateral", "spherical", "elliptic", "hyperbolic", "pentagon",
                "hexagon", "rhombus", "parallelogram", "trapezoid", "trapezium", "isosceles", "kite", "irregular", "antiparallelogram", "pentagram", "hexagram", "heptagram",
                "circle", "circumscribed", "circumcircle", "function", "domain", "codomain", "power", "pair", "pairs", "variable", "index", "indexes", "notation",
                "composition", "relation", "relations", "infinite", "interval", "transformation", "monoid", "permutation", "permuting", "combination", "bijection",
                "combinatorics", "optimization", "plot", "plots", "table", "chart", "bar", "equality", "injective", "surjective", "bijective", "restriction", "extension",
                "multivariate", "quadratic", "surface", "cube", "cubic", "face", "faces", "facet", "facets", "slide", "slides", "vertex", "tetrahedron", "cuboid", "cone",
                "ball", "sphere", "pyramid", "apex", "base", "oblique", "star", "formal", "deductive", "intuitionistic", "law", "middle", "negation", "implication",
                "elimination", "introduction", "conditional", "boolean", "converse", "tautology", "contradiction", "statement", "claim", "variable", "real", "natural",
                "complex", "axiom", "rational", "imaginary", "period", "periodic", };
            TMP = new dziedzina("matematyka", tmp);
            dziedziny.Add(TMP);
        }

    }
}
